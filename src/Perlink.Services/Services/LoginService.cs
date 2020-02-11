using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Perlink.Data;
using Perlink.Services.Base;
using Perlink.Services.Helpers;

namespace Perlink.Services
{
    public class LoginService : ServiceBase
    {
        private PerlinkDbContext _context;
        private IConfiguration _configuration;

        public LoginService(PerlinkDbContext context) : base(context)
        {
            _context = context;
        }

        public LoginService() : this(new PerlinkDbContext(new DbContextOptions<PerlinkDbContext>()))
        {
        }

        
        /*

        public ServiceEnums.LoginState TryLogin(object loginViewModel)
        {
            //SecretMD5Key must be "b49d6c03fe471ee720b5a4d56c5a9bf2" for secretKey below
            //SecretKey = 2011 and password = 123

            var account = new Account();
            MapHelper.MapFrom(loginViewModel, account);

            var passwordMd5 = GetPasswordMD5Hash(account.Password);
            var accountExist = _context.Account.Select(acc => new { acc.Username, acc.Password }).FirstOrDefault(a => a.Username == account.Username && account.Password == passwordMd5);
            
            if (accountExist != null)
            {
                return ServiceEnums.LoginState.Success;
            }

            return ServiceEnums.LoginState.NotFound;
        }

        public ServiceEnums.RegisterState TryCreateAccount(object loginViewModel)
        {
            var ac = new Account();

            MapHelper.MapFrom(loginViewModel, ac);
            
            var accountExist = _context.Account.Select(account => new { account.Username, account.Email }).FirstOrDefault(a => a.Username == ac.Username || a.Email == ac.Email);
            
            if (string.IsNullOrEmpty(accountExist?.Username) && string.IsNullOrEmpty(accountExist?.Email))
            {
                var newRecord = new Account();
                MapHelper.MapFrom(loginViewModel, newRecord);

                //This fields cannot be null in database and must be filled.
                //newRecord.IP_user = "127.0.0.1";
                //newRecord.block = 0;

                try
                {
                    _context.Account.Add(newRecord);
                    _context.SaveChanges();
                    return ServiceEnums.RegisterState.Success;
                }
                catch (DbUpdateException ex)
                {
                    return ServiceEnums.RegisterState.InternalError;
                }
            }

            return ServiceEnums.RegisterState.Exists;
        }

        */

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

    
    }
}
