using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.ServiceAbstraction;
using Talabat.Shared.IdentityDTO;

namespace Talabat.Presentation.Controllers
{
   public class AuthenticationController(IServiceManager serviceManager) :BaseApiController
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto loginDto)
        {
            return Ok(await serviceManager.AuthenticationService.LoginAsync(loginDto));
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> RegisterAsync(RegisterDto registerDto)
        {
            return Ok(await serviceManager.AuthenticationService.RegisterAsync(registerDto));
        }
    }
}
