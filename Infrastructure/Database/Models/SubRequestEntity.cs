using Infrastructure.Database.Models.Audit;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database.Models
{
    [Table("SUBREQUEST")]
    public sealed class SubRequestEntity : UpdateableEntity<Guid>
    {
        public override Guid Id { get; set; }
        public Guid RequestId { get; set; }

        [ForeignKey("RequestId")]
        public RequestEntity Request { get; set; }
    }
}
