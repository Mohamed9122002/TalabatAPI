using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts.IdentityModule;
using Talabat.DomainLayer.Exceptions;
using Talabat.ServiceAbstraction;
using Talabat.Shared.IdentityDTO;

namespace Talabat.ServiceImplemention
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager) : IAuthenticationService
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            // check if the user is exist or not 
            var User = await _userManager.FindByEmailAsync(loginDto.Email) ?? throw new UserNotFoundException(loginDto.Email);
            // Check Password 
            var IsPasswordValid = await _userManager.CheckPasswordAsync(User, loginDto.Password);
            if (IsPasswordValid)
            {
                return new UserDto()
                {
                    DispalyName = User.DisplayName,
                    Email = User.Email,
                    Token = string.Empty // TODO: Generate Token
                };
            }
            else
            {
                throw new UnauthorizedException();
            }
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            // Mapping RegisterDto to ApplicationUser 
            var User = new ApplicationUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.Email,
            };
            // Create User  [Application User ]
            var Result = await _userManager.CreateAsync(User, registerDto.Password);
            // Return UserDto 
            if (Result.Succeeded)
            {
                return new UserDto { DispalyName = User.DisplayName, Email = User.Email, Token = string.Empty }; // TODO: Generate Token
            }
            else
            {
                var Errors = Result.Errors.Select(x => x.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }
    }
}
