using Perlink.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Perlink.Web.Models
{
    public class LawViewModel
    {
        public string NumeroDoProcesso { get; set; }
        public DateTime dataDeCriacaoDoProcesso { get; set; }
        public decimal valor { get; set; }
        public Lawoffice escritorio { get; set; }
        public int escritorioId { get; set; }
    }
}
