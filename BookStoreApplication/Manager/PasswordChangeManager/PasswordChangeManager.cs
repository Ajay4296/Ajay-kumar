using BookStoreRepositoryLayer.ResetPassword;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussinessLayer.PasswordChangeManager
{
   public class PasswordChangeManager :IChangePasswordManager
    {
        private readonly IChangePassword changePassword;

        public PasswordChangeManager(IChangePassword changePassword)
        {
            this.changePassword = changePassword;
        }
       public string ChangePassword(string Email, string OldPassword,string NewPassword)
        {
            return changePassword.PasswordChange(Email, OldPassword,NewPassword);
        }
    }
}
