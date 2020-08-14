using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;

namespace Repository.AddressRepository
{
    public interface IAddressRepository
    {
        IEnumerable<AddressModel> GetAllAddress();
        void Addaddress(AddressModel addressModel);
    }
}
