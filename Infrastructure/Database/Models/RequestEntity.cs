using Infrastructure.Database.Models.Audit;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database.Models
{
    [Table("REQUEST")]
    public sealed class RequestEntity : UpdateableEntity<Guid>
    {
        public override Guid Id { get; set; }

        public SubRequestEntity SubRequest { get; set; }
    }
}
