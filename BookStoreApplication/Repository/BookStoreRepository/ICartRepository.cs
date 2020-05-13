using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Model;

namespace Repository.Repository
{
    public interface ICartRepository
    {
      Task<int> AddCart(CartModel cartModel);
       CartModel DeleteCart(int id);
        int CountCart();
        IEnumerable<BookStoreModel> GetAllCartValue();


    }
}
