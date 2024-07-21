using Infrastructure.Database.Models.AuditModels.Interfaces;
using NPoco;

namespace Infrastructure.Database.Models.AuditModels
{
    public class CreateableEntity : ICreateableEntity
    {
        [Column("DATE_CREATED_UTC_DTE")]
        public DateTime DateCreatedUtcDte { get; set; } = DateTime.UtcNow;
        [Column("CREATED_BY_ID")]
        public Guid CreatedById { get; set; }
    }
}
