using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Contracts
{
    public abstract class CreatableEntity<T> : Entity<T>, ICreatableEntity
    {
        [Required]
        [Column("DATE_CREATED_UTC_DTE", TypeName = "timestamp")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Column("CREATED_BY_ID", TypeName = "uuid")]
        public Guid CreatedBy { get; set; }
    }
}
