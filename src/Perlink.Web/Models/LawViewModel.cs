using Perlink.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perlink.Web.Models
{
    public class LawViewModel
    {
        /*
        public string SuitNumber { get; set; }
        public DateTime SuitCreationTime { get; set; }
        public decimal CourtCosts { get; set; }
        public Lawoffice Lawoffice { get; set; }
        public int LawofficeId { get; set; }

        public string Name { get; set; }
        public IList<Lawsuit> Lawsuits { get; set; }
        

        "numeroDoProcesso": "<string>",
        "dataDeCriacaoDoProcesso": <DateTime>,
        "valor": <decimal>
        "escritorio" : "<string>"
        */

        public string numeroDoProcesso { get; set; }
        public DateTime dataDeCriacaoDoProcesso { get; set; }
        public decimal valor { get; set; }
        public Lawoffice escritorio { get; set; }
        public int escritorioId { get; set; }
    }
}
