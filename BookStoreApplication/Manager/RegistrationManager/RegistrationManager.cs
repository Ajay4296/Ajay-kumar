using BookStoreRepositoryLayer.Registratoin;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.RegistrationManager
{
   public class RegistrationManager:IRegistrationManager
    {
        private readonly IRegistrationRepo registrationRepo;

        public RegistrationManager(IRegistrationRepo registrationRepo )
        {
            this.registrationRepo = registrationRepo;
        }

      public  IEnumerable<Registration> GetRegistrations()
        {
            return registrationRepo.GetRegistrations();
        }

       public int AddRegistration(Registration registration)
        {
         return registrationRepo.AddRegistration(registration);
        }
      public int Login(string Email, string Password)
        {
            return registrationRepo.Login(Email, Password);
        }
    }
}
