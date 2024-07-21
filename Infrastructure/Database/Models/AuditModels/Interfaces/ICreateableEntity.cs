using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Models.AuditModels.Interfaces
{
    internal interface ICreateableEntity
    {
        public DateTime DateCreatedUtcDte { get; set; }
        public Guid CreatedById { get; set; }
    }
}
