using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Shared.IdentityDTO
{
    public class UserDto
    {
        [EmailAddress]
        public string Email { get; set; } = default!;
        public string DispalyName { get; set; } = default!;
        public string Token { get; set; } = default!;

    }
}
