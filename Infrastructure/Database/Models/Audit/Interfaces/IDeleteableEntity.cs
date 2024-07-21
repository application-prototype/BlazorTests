using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Models.AuditModels.Interfaces
{
    internal interface IDeleteableEntity : ICreateableEntity
    {
        public DateTime? DateDeletedUtcDte { get; set; }
        public Guid? DeletedById { get; set; }
    }
}
