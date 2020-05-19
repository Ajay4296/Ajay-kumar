using Model.Model;
using Repository.DBContext;
using System.Threading.Tasks;

namespace Repository.AddressRepository
{
    /// <summary>
    /// business code is written here
    /// </summary>
    /// <seealso cref="Repository.AddressRepository.IAddressRepository" />
    public class ProductAddressRepository :IAddressRepository
    {
        /// <summary>
        /// The address database
        /// </summary>
        private readonly UserDbContext addressDB;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAddressRepository"/> class.
        /// </summary>
        /// <param name="addressDB">The address database.</param>
        public ProductAddressRepository(UserDbContext addressDB)
        {
            this.addressDB = addressDB;
        }

        /// <summary>
        /// Gets the customer address.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public AddressModel GetCustomerAddress(string email)
        {
            return addressDB.AddressSpace.Find(email);
        }

        /// <summary>
        /// Adds the detail address.
        /// </summary>
        /// <param name="addressModel">The address model.</param>
        /// <returns></returns>
        public Task<int> AddDetailAddress(AddressModel addressModel)
        {
            addressDB.AddressSpace.Add(addressModel);           
            var result = addressDB.SaveChangesAsync();
            return result;
        }    
               
    }
}
