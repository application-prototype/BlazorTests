using Infrastructure.Database.Entities;
using Infrastructure.Database.Models.AuditModels;
using NPoco;

namespace Infrastructure.Database.Models
{
    [TableName("SUBREQUEST")]
    [PrimaryKey("Id", AutoIncrement = false)]
    public sealed class SubRequestEntity : UpdateableEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("RequestId")]
        public Guid RequestId { get; set; }

        //[Reference(ReferenceType.Foreign, ColumnName = "RequestId", ReferenceMemberName = "RequestId")]
        //public RequestEntity Request { get; set; }
    }
}
