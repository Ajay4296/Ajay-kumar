using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;

namespace Manager.AddressManager
{
    /// <summary>
    /// Interface class of the IAddress manager 
    /// </summary>
    public interface IAddressManager
    {
        IEnumerable<AddressModel> GetAllAddress();
        void AddAddress(AddressModel addressModel);
    }
}
