using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    /// <summary>
    /// Interface class of Login repository
    /// </summary>
    public interface ILoginRepo
    {
        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>It return true if Login successful.</returns>
        bool Login(User userChanges);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>It return 1 if user added successfully</returns>
        Task<int> AddUser(User user);
    }
}
