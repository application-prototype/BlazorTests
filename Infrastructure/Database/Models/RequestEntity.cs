using Infrastructure.Database.Models.AuditModels;
using NPoco;

namespace Infrastructure.Database.Entities
{
    [TableName("REQUEST")]
    [PrimaryKey("Id", AutoIncrement = false)]

    // class can inherit only one direct base class, single inheritance in c#
    public sealed class RequestEntity : UpdateableEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }
    }
}
