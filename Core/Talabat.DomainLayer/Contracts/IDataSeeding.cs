﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Contracts
{
    public interface IDataSeeding
    {
        Task DataSeedAsync();
        Task IdentityDataSeedAsync();
    }
}
