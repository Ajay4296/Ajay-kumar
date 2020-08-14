/*using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStoreBussinessLayer.RegistrationManager;
using BookStoreRepositoryLayer.Common;
using Microsoft.AspNetCore.Authorization;
//using BookStoreRepositoryLayer.JsonErrorHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Model;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationManager registrationManager;
        private readonly IConfiguration config;

        public RegistrationController(IRegistrationManager registrationManager, IConfiguration config)
        {
            this.registrationManager = registrationManager;
            this.config = config;
        }

        [HttpPost]
        public IActionResult AddRegistration(Registration registration)
        {
            int result = registrationManager.AddRegistration(registration);
            if (result == 0)
            {
                return this.BadRequest(JsonErrorModel.Json());
            }
            else
                return this.Ok(registration);
        }

        [HttpGet]
        public IEnumerable<Registration> GetRegistrations()
        {
            return registrationManager.GetRegistrations();
        }

        [Route("signIn")]
        [HttpGet]
        public IActionResult Login(string Email, string Password)
        {
            //  WebToken token = new WebToken(config);
            var result = this.registrationManager.Login(Email, Password);
            if (result == 1)
            {
                string Message = "Successfully Login";
                string jsonToken = GenerateToken(Email, Password, "User");
                return this.Ok(new { Message, jsonToken });
                //  return this.Ok(jsonToken);
            }
            return this.BadRequest(JsonErrorModel.Json());
        }

        private string GenerateToken(string Email, string Password, string type)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, type));
                claims.Add(new Claim("Email", Email.ToString()));
                claims.Add(new Claim("Password", Password.ToString()));
                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
*/