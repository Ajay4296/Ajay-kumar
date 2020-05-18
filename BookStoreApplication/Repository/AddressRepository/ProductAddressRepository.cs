using Model.Model;
using Repository.Common;
using Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public AddressModel GetCustomerAddress(string email)
        {
            return addressDB.AddressSpace.Find(email);
        }
        public Task<int> AddDetailAddress(AddressModel addressModel)
        {
            addressDB.AddressSpace.Add(addressModel);           
            var result = addressDB.SaveChangesAsync();
            return result;
        }
       
               
    }
}
