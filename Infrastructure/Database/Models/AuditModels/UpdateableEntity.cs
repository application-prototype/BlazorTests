using Infrastructure.Database.Models.AuditModels.Interfaces;
using NPoco;

namespace Infrastructure.Database.Models.AuditModels
{
    public class UpdateableEntity: DeletableEntity, IUpdateableEntity
    {
        [Column("UpdatedDateUTC")]
        public DateTime DateUpdatedUtcDte { get; set; }
        [Column("UpdatedBy")]
        public Guid UpdatedById { get; set; }
    }
}