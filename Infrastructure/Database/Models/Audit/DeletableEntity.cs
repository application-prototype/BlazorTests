using Infrastructure.Database.Models.AuditModels.Interfaces;
using NPoco;

namespace Infrastructure.Database.Models.AuditModels
{
    public class DeletableEntity : CreateableEntity, IDeleteableEntity
    {
        [Column("DATE_DELETED_UTC_DTE")]
        public DateTime? DateDeletedUtcDte { get; set; }
        [Column("DELETED_BY_ID")]
        public Guid? DeletedById { get; set; }
    }
}