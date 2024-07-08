using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Contracts
{
    public abstract class Entity<T> : IEntity<T>
    {
        [Key]
        [Required]
        public virtual T Id { get; set; } = default!;

        object IEntity.Id
        {
            get => Id!;
            set => Id = (T)value;
        }
    }

}
