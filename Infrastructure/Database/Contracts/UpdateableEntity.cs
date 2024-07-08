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
    public abstract class UpdateableEntity<T> : DeletableEntity<T>, IUpdateableEntity
    {
        //[Required]
        //[Column("DATE_LAST_UPDATED_UTC_DTE", TypeName = "timestamp")]
        public DateTime UpdatedDateUTC { get; set; }

        //[Required]
        //[Column("LAST_UPDATED_BY_ID", TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }
    }
}
