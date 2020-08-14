using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussinessLayer.PasswordChangeManager
{
  public  interface IChangePasswordManager
    {
        string ChangePassword(string Email,string Password,string NewPassword);
    }
}
