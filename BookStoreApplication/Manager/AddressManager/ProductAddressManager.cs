using System.Collections.Generic;
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

        public IEnumerable<AddressModel> GetAllAddress()
        {
            return addressRepository.GetAllAddress();
        }
        public void AddAddress(AddressModel addressModel)
        {
            addressRepository.Addaddress(addressModel);
        }
    }
}
