using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Perlink.Data;
using Perlink.Data.Data;
using Perlink.Services.Base;
using Perlink.Services.Helpers;
using Remotion.Linq.Clauses;

namespace Perlink.Services
{
    public class MainService : ServiceBase
    {
        private PerlinkDbContext _context;

        public MainService(PerlinkDbContext context) : base(context)
        {
            _context = context;
        }

        //todo: não vou implementar nesse desafio mas, já deixo pronto para usar em outros
        public string GetPasswordMD5Hash(string password)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var secretKey = configuration["SecretMD5Key:SecretKey"];

            var bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(secretKey + password));
            StringBuilder builder = new StringBuilder();

            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }

            return builder.ToString();
        }

        public ICollection<Lawsuit> GetLawsuitList()
        {
            var list = _context.Lawsuit.Include(x => x.Lawoffice).ToList();
            return list;
        }

        public ServiceEnums.CreateState Create(Lawsuit lawsuit)
        {
            try
            {
                Insert(lawsuit);
                return ServiceEnums.CreateState.Success;
            }
            catch (DbUpdateException ex)
            {
                return ServiceEnums.CreateState.InternalError;
            }
        }
    }
}
