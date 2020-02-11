using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Perlink.Data.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreationTime { get; set; }
    }
}
