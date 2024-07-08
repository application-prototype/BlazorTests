using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Contracts
{
    public interface IDeletableEntity : ICreatableEntity
    {
        DateTime? DeletedOn { get; set; }
        Guid? DeletedBy { get; set; }
        string? DeletedReason { get; set; }
    }
}
