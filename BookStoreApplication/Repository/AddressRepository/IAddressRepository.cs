using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AddressRepository
{
   public interface IAddressRepository
    {
        IEnumerable<AddressModel> GetAddress();
        Task<int> AddDetailAddress(AddressModel addressModel);
        bool Login(AddressModel addressModel);
    }
}
