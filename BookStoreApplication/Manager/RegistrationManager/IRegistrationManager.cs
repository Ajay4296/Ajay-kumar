using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.RegistrationManager
{
   public interface IRegistrationManager
    {
        IEnumerable<Registration> GetRegistrations();

        int AddRegistration(Registration registratoin);

        int Login(string Email, string Password);
    }
}
