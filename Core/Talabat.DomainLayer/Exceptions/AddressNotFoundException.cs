using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Exceptions
{
    public sealed class AddressNotFoundException(string UserName) : Exception($"User{UserName}Has No Address")
    {

    }
}
