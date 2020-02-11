using System;
using System.Collections.Generic;
using System.Text;
using Perlink.Data.Interfaces;

namespace Perlink.Data.Data
{
    public class Lawoffice : Entity
    {
        public string Name { get; set; }
        public IList<Lawsuit> Lawsuits { get; set; }
    }
}
