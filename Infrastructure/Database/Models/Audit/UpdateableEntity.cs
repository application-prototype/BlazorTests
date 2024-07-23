using Infrastructure.Database.Models.AuditModels.Interfaces;
using NPoco;

namespace Infrastructure.Database.Models.AuditModels
{
    public class UpdateableEntity: DeletableEntity, IUpdateableEntity
    {
        [Column("DATE_LAST_UPDATED_UTC_DTE")]
        public DateTime DateUpdatedUtcDte { get; set; } = DateTime.UtcNow;
        [Column("LAST_UPDATED_BY_ID")]
        public Guid UpdatedById { get; set; }
    }
}