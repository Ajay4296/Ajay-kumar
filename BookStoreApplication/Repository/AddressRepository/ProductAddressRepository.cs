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
       

        public object LoginID(string Email,string _Password)
        {
            try
            {
                AddressModel address = addressDB.AddressSpace.Find(Email);
                if (address==null || address.Password != _Password)
                {
                    throw new BookStoreException("invalid password or Email");
                }
                return address;
             }
            catch (BookStoreException e)
            {
                return e.Message;
            }
            
        }        
    }
}
