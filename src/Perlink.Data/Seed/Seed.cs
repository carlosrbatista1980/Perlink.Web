using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Perlink.Data.Seed
{
    public class Seed
    {
        private PerlinkDbContext _context;

        public Seed(PerlinkDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            /*

            if (!_context.Account.Any())
            {
                Console.WriteLine("Running Seed...");

                var AccountSeedData = new[]
                {
                    new {id = 1, username = "admin1", password = "123", phone = "21-9998880008", lastlogintime = DateTime.Now,},
                    new {id = 2, username = "admin2", password = "223", phone = "22-9998880008", lastlogintime = DateTime.Now,},
                    new {id = 3, username = "admin3", password = "323", phone = "23-9998880008", lastlogintime = DateTime.Now,},
                    new {id = 4, username = "admin4", password = "423", phone = "24-9998880008", lastlogintime = DateTime.Now,},
                };

                foreach (var item in AccountSeedData)
                {
                    Account account = new Account()
                    {
                        Username = item.username,
                        Password = item.password,
                        Phone = item.phone,
                        LastLoginTime = item.lastlogintime,
                    };

                    _context.Account.Add(account);
                }

                try
                {
                    _context.SaveChanges(true);
                    Console.WriteLine("Running Seed...OK");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("Running Seed...ERROR: " + ex.Message);
                }
            }

            */
        }
    }
}
