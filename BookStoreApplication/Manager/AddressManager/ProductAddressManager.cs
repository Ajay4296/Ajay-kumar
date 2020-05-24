using System.Threading.Tasks;
using Model.Model;
using Repository.AddressRepository;

namespace Manager.AddressManager
{
    /// <summary>
    /// Implementation of the Address manager interface
    /// </summary>
    /// <seealso cref="Manager.AddressManager.IAddressManager" />
    public class ProductAddressManager : IAddressManager
    {
        /// <summary>
        /// The address repository
        /// </summary>
        private readonly IAddressRepository addressRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAddressManager"/> class.
        /// </summary>
        /// <param name="addressRepository">The address repository.</param>
        public ProductAddressManager(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        /// <summary>
        /// Gets the customer address.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public AddressModel GetCustomerAddress(string email)
        {
            return this.addressRepository.GetCustomerAddress(email);
        }

        /// <summary>
        /// Adds the detail address.
        /// </summary>
        /// <param name="addressModel">The address model.</param>
        /// <returns></returns>
        public Task<int> AddDetailAddress(AddressModel addressModel)
        {
            return this.addressRepository.AddDetailAddress(addressModel);
        }

    }
}
