﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Exceptions
{
    public sealed class UnauthorizedException(string Message = "Invalid Email Or Password") : Exception(Message)
    {
    }
}
