using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Contracts
{
    public interface IEntity
    {
        object Id { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }

}
