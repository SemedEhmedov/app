using AutoMapper;
using Business.DTOs.Account;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration config)
        {
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task Register(RegisterDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) != null)
            {
                throw new Exception("bele email var");
            }
            var User = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(User, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new Exception(sb.ToString());
            }
        }
        public async Task<string> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user != null)
            {
                throw new Exception("nese sehvdi");
            }
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result) throw new Exception("nese sehvdi");
            var _claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                audience: _config["Jwt:Audience"],
                issuer: _config["Jwt:Issuer"],
                claims: _claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddDays(1)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;

        }
    }
}
