using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Models.Audit
{
    public abstract class DeletableEntity<T> : CreatableEntity<T>, IDeletableEntity
    {
        [Column("DATE_DELETED_UTC_DTE", TypeName = "timestamp")]
        public DateTime? DeletedOn { get; set; }

        [Column("DELETED_BY_ID", TypeName = "uuid")]
        public Guid? DeletedBy { get; set; }

        [Column("DELETE_REASON_CD", TypeName = "varchar(100)")]
        public string? DeletedReason { get; set; }
    }
}
