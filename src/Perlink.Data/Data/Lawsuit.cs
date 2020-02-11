using System;
using System.Collections.Generic;
using System.Text;
using Perlink.Data.Interfaces;

namespace Perlink.Data.Data
{
    public class Lawsuit : Entity
    {
        public string SuitNumber { get; set; }
        public DateTime SuitCreationTime { get; set; }
        public decimal CourtCosts { get; set; }
        public Lawoffice Lawoffice { get; set; }
        public int LawofficeId { get; set; }
    }
}
