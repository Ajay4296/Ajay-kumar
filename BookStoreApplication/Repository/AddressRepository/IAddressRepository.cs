using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AddressRepository
{
   public interface IAddressRepository
    {
        AddressModel GetCustomerAddress(string email);
        Task<int> AddDetailAddress(AddressModel addressModel);
    }
}
