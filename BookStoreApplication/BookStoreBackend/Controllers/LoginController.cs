using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.LoginManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using BookStoreRepositoryLayer.Common;

namespace BookStoreBackend.Controllers
{
   
    /// <summary>
    /// Login controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// The login manager
        /// </summary>
        private readonly ILogin loginManager;

        public class JsonErrorModel
        {
            public int ErrorCode { get; set; }

            public string ErrorMessage { get; set; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="loginManager">The login manager.</param>
        public LoginController(ILogin loginManager)
        {
            this.loginManager = loginManager;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
       // [Route("")]
        [HttpPost]
        public async Task<IActionResult> GetUser(User user)
        {
            var result = await this.loginManager.AddUser(user);

            if (result == 1)
            {
                return this.Ok(user);
            }            
                return this.BadRequest(JsonReturn());
            
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(User userChanges)
        {
            var result = this.loginManager.Login(userChanges);
            if (result == true)
            {
                return this.Ok(userChanges);
            }

            return this.BadRequest(JsonReturn());
        }

        /// <summary>
        /// Jsons the return.
        /// </summary>
        /// <returns></returns>
        private object JsonReturn()
        {
            var error = new JsonErrorModel
            {                
                ErrorMessage = "Login Error"
            };

            return error;
        }
    }

}