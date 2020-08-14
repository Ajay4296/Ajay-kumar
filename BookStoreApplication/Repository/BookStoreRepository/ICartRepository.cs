using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Model;

namespace Repository.Repository
{
    /// <summary>
    /// interface class of IcartRepository
    /// </summary>
    public interface ICartRepository
    {
        int AddCart(CartModel cartModel);
       string  DeleteCart(int id);

        int CartCount();

        IEnumerable<BookStoreModel> GetCart();

    }
}
