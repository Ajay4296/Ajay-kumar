using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.ResetPassword
{
   public interface IChangePassword
    {
        string PasswordChange(string Email, string OldPassword,string NewPassword);
    }
}
