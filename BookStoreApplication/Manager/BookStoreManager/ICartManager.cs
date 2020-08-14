using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Model;

namespace Manager.Manager
{
    public interface ICartManager
    {
        int AddCart(CartModel cartModel);

        string DeleteCart(int id);

        int CountCart();

        IEnumerable<BookStoreModel> GetCart();
    }
}
