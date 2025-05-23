﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.ServiceAbstraction;
using Talabat.Shared.IdentityDTO;

namespace Talabat.Presentation.Controllers
{
    public class AuthenticationController(IServiceManager serviceManager) : BaseApiController
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
        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var Result = await serviceManager.AuthenticationService.CheckEmailAsync(email);
            return Ok(Result);
        }
        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentuser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var AppUser = await serviceManager.AuthenticationService.GetCurrentUserAsync(Email!);
            return Ok(AppUser);
        }
        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var Address = await serviceManager.AuthenticationService.GetCurrentUserAddressAsync(Email!);
            return Ok(Address);
        }
        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDto>> UpdateCurrentUserAddress(AddressDto addressDto)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var UpdatedAddress = await serviceManager.AuthenticationService.UpdateCurrentAddressAsync(addressDto, Email!);
            return Ok(UpdatedAddress);
        }
    }
}
