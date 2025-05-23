﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts.IdentityModule;
using Talabat.DomainLayer.Exceptions;
using Talabat.ServiceAbstraction;
using Talabat.Shared.IdentityDTO;

namespace Talabat.ServiceImplemention
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager, IConfiguration _configuration) : IAuthenticationService
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
                    Token = await CreateTokenAsync(User)
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
                return new UserDto { DispalyName = User.DisplayName, Email = User.Email, Token = await CreateTokenAsync(User) };
            }
            else
            {
                var Errors = Result.Errors.Select(x => x.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }
        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            // Payload
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                //new Claim(ClaimTypes.Role,user.Role),

            };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var Role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, Role));
            }
            // Key 
            var SecretKey = _configuration.GetSection("JWTOptions")["SecretKey"];
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            // Credentials 
            var Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            // Create Token 
            var Token = new JwtSecurityToken(
                issuer: _configuration["JWTOptions:Issuer"],
                audience: _configuration["JWTOptions:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: Credentials);
            // Return Token
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
