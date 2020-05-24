using System.Threading.Tasks;
using Model.Model;

namespace Repository.AddressRepository
{
    public interface IAddressRepository
    {
        AddressModel GetCustomerAddress(string email);
        Task<int> AddDetailAddress(AddressModel addressModel);
    }
}
