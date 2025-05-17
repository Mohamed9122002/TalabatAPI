using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Exceptions
{
    public sealed class BasketNotFoundException(string Id) : NotFoundException($"Basket With {Id} is Not Found")

    {


    }
}
