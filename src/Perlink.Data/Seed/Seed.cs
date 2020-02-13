using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Perlink.Data.Data;


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
            if (!_context.Lawoffice.Any())
            {
                Console.WriteLine("Seeding Offices ...");

                var lawoffices = new[]
                    {
                        new {id = 1, name = "escritorio botafogo"},
                        new {id = 2, name = "escritorio centro"},
                        new {id = 3, name = "escritorio barra"},
                    };

                foreach (var office in lawoffices)
                {
                    var escritorio = new Lawoffice();
                    
                    escritorio.Id = office.id;
                    escritorio.Name = office.name;
                    escritorio.CreationTime = DateTime.Now;

                    _context.Lawoffice.Add(escritorio);
                    _context.SaveChanges();
                }

                Console.WriteLine("Seeding Offices ...OK");
            }


            if (!_context.Lawsuit.Any())
            {
                Console.WriteLine("Seeding LawSuits ...");

                var lawsuits = new[]
                {
                    new {id = 1, suitNumber = "001-002", courtCosts = 299m, lawofficeId = 1},
                    new {id = 2, suitNumber = "002-002", courtCosts = 199m, lawofficeId = 2},
                    new {id = 3, suitNumber = "003-002", courtCosts = 399m, lawofficeId = 2},
                    new {id = 4, suitNumber = "004-002", courtCosts = 499m, lawofficeId = 3},
                };

                foreach (var lawsuit in lawsuits)
                {
                    var processo = new Lawsuit();

                    processo.Id = lawsuit.id;
                    processo.SuitNumber = lawsuit.suitNumber;
                    processo.CourtCosts = lawsuit.courtCosts;
                    processo.SuitCreationTime = DateTime.Now;
                    processo.LawofficeId = lawsuit.lawofficeId;

                    _context.Lawsuit.Add(processo);
                    _context.SaveChanges();
                }

                Console.WriteLine("Seeding LawSuits ...OK");
            }
        }
    }
}
