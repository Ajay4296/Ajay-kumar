using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.AddressManager
{
   public interface IAddressManager
    {
        IEnumerable<AddressModel> GetAddress();
        Task<int> AddDetailAddress(AddressModel addressModel);      
        AddressModel LoginID(string Email);
    }
}
