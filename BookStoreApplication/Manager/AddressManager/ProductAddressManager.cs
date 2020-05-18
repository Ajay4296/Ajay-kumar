using Model.Model;
using Repository;
using Repository.AddressRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.AddressManager
{
   public class ProductAddressManager : IAddressManager
    {
        private readonly IAddressRepository addressRepository;
        public ProductAddressManager(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }


        public AddressModel GetCustomerAddress(string email)
        {
            return this.addressRepository.GetCustomerAddress(email);
        }

        public Task<int> AddDetailAddress(AddressModel addressModel)
        {
            return this.addressRepository.AddDetailAddress(addressModel);
        }
    
    }
}
