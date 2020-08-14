using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.PasswordChangeManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly IChangePasswordManager passwordManager;
        public ChangePasswordController(IChangePasswordManager passwordManager)
        {
            this.passwordManager = passwordManager;
        }

        [HttpPut]
        [Route("Change Password")]
        public string ChangePassword(string Email, string OldPassword,string NewPassword)
        {
            return passwordManager.ChangePassword(Email, OldPassword,NewPassword);
        }
    }
}
