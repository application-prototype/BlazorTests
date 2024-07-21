using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Models.AuditModels.Interfaces
{
    internal interface IUpdateableEntity : IDeleteableEntity
    {
        public DateTime DateUpdatedUtcDte { get; set; }
        public Guid UpdatedById { get; set; }
    }
}
