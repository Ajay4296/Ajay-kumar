﻿/*using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreWebApi.Controllers
{
    /// <summary>
    /// TokenGenerator class controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenGeneratorController : ControllerBase
    {
        private IConfiguration _config;

        public TokenGeneratorController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("GetTokken")]
        public object GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}*/