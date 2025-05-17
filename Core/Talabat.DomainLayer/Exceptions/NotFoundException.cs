using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Exceptions
{
    public abstract class NotFoundException(string Message) : Exception(Message)
    {

    }
}
