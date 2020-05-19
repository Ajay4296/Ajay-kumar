using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.AddressManager
{
   public interface IAddressManager
    {
        AddressModel GetCustomerAddress(string email);
        Task<int> AddDetailAddress(AddressModel addressModel);
    }
}
