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
        // Check Email 
        // Take string Email Then Return  Boolean
        Task<bool> CheckEmailAsync(string email);
        // Get Current User Address 
        // Take string  Email Then Return AddressDto 
        Task<AddressDto> GetCurrentUserAddressAsync(string email);
        // Update Current User Address 
        // Take AddressDto Updated Address and string Email Then Return AddressDto  Address After Update
        Task<AddressDto> UpdateCurrentAddressAsync(AddressDto addressDto, string email);
        // Get Current User
        // Take string Email Then Return UserDto Token ,  Email and DisplayName 
        Task<UserDto> GetCurrentUserAsync(string email);
    }
}
