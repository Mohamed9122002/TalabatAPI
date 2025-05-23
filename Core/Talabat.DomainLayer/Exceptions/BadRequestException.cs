using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Exceptions
{
    public sealed class BadRequestException(List<string> errors) : Exception("Validation Errors")
    {
        public List<string> Errors { get; } = errors;
    }

}
