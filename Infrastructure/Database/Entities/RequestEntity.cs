using Infrastructure.Database.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Entities
{
    [Table("REQUEST")]
    public sealed class RequestEntity : UpdateableEntity<Guid>
    {
        public override Guid Id { get; set; }
    }
}
