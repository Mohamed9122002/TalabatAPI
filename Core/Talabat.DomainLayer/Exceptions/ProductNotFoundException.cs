﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Exceptions
{
    public sealed class ProductNotFoundException(int id ) :NotFoundException($"Product With id = {id} is not Found ")
    {
        
    }
}
