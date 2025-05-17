using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Shared.ErrorModles
{
    public class ValidationError
    {
        public string Field { get; set; } = default!;
        public IEnumerable<string> Errors { get; set; } = [];


    }
}
