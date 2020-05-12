using Model.Model;
using Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AddressRepository
{
   public class ProductAddressRepository :IAddressRepository
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
        public bool Login(AddressModel addressModel)
         {
            var result = addressDB.AddressSpace.Where(items => items.Email == addressModel.Email && items.Password == addressModel.Password).FirstOrDefault();

            if (result != null)
            {
                return true;
            }
            return false;
        }   
    }
}
