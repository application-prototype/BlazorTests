﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Contracts
{
    public interface IUpdateableEntity : IDeletableEntity
    {
        DateTime UpdatedDateUTC { get; set; }
        Guid UpdatedBy { get; set; }
    }
}
