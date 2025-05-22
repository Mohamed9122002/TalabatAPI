using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Shared.IdentityDTO;

namespace Talabat.ServiceAbstraction
{
    public interface IAuthenticationService
    {
        // Login 
        // Take Email and Password Then Return Token , Email and DispalyName 
        Task<UserDto> LoginAsync(LoginDto loginDto);
        // Register
        // Take DispalyName,UserName,PhonNumber,Email,Password Then Return Token , Email and DispalyName
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
    }
}
