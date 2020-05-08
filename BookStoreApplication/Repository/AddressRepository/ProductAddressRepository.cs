using Model.Model;
using Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class ProductAddressRepository
    {
        private readonly UserDbContext addressDB;

        public ProductAddressRepository(UserDbContext addressDB)
        {
            this.addressDB = addressDB;
        }

        public IEnumerable<AddressModel> GetAddress()
        {
            return addressDB.AddressSpace;
        }
        public Task<int> AddDetailAddress(AddressModel addressModel)
        {
            addressDB.AddressSpace.Add(addressModel);
            var result = addressDB.SaveChangesAsync();
            return result;
        }
    }
}
