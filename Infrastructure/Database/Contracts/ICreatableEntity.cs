﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Contracts
{
    public interface ICreatableEntity
    {
        DateTime CreatedOn { get; set; }
        Guid CreatedBy { get; set; }
    }

}
