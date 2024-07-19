using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public interface INPocoDbContext
    {
        public int GetRequestId();
        public void AddRequest();
    }
}
