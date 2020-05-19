using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.AddressManager
{
    /// <summary>
    /// Interface class of the IAddress manager 
    /// </summary>
    public interface IAddressManager
    {
        /// <summary>
        /// Gets the customer address.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        AddressModel GetCustomerAddress(string email);

        /// <summary>
        /// Adds the detail address.
        /// </summary>
        /// <param name="addressModel">The address model.</param>
        /// <returns></returns>
        Task<int> AddDetailAddress(AddressModel addressModel);
    }
}
