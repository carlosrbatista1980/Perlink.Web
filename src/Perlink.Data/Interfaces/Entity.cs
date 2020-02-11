using System;
using System.Collections.Generic;
using System.Text;

namespace Perlink.Data.Interfaces
{
    /// <summary>
    /// Não é necessário colocar Id ou CreationTime nas entidades porque elas já se configuram automaticamente
    /// Caso outro campo seja requerido basta adicionar na Interface.
    /// </summary>

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
