using Model.Model;
using Repository.LoginRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.LoginManager
{
    public class ImpLoginManager : ILogin
    {
        /// <summary>
        /// The login repository
        /// </summary>
        private readonly ILoginRepo loginRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginManagerImpl"/> class.
        /// </summary>
        /// <param name="loginRepository">The login repository.</param>
        public ImpLoginManager(ILoginRepo loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// It return 1 if user added successfully
        /// </returns>
        public Task<int> AddUser(User user)
        {
            return this.loginRepository.AddUser(user);
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// It return true if Login successful.
        /// </returns>
        public bool Login(User userChanges)
        {
            return this.loginRepository.Login(userChanges);
        }
    }
}
