using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Model;
using Repository.DBContext;

namespace Repository.Repository
{
    public class CartRepository : ICartRepository
    {
        
        private readonly UserDbContext userDbContext;

        public CartRepository(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public Task<int> AddCart(CartModel cartModel)
        {
            userDbContext.CartTable.Add(cartModel);
            var result = userDbContext.SaveChangesAsync();
            return result;
        }

        public CartModel DeleteCart(int id)
        {
           CartModel cartModel= userDbContext.CartTable.Find(id);
            if (cartModel != null)
            {
                userDbContext.CartTable.Remove(cartModel);
                userDbContext.SaveChanges();
            }
            return cartModel;
        }

        public int CountCart()
        {
            var result = userDbContext.CartTable.ToList();
            return result.Count;
        }

        public IEnumerable<BookStoreModel> GetAllCartValue()
        {
            List<CartModel> cartList = new List<CartModel>();
            List<BookStoreModel> getAllCartByBookType = new List<BookStoreModel>();
            cartList = userDbContext.CartTable.ToList();
            for (int i = 0; i < cartList.Count; i++)
            {
                getAllCartByBookType.Add(userDbContext.BookStore.Find(cartList[i].Book_ID));
            }

            //foreach(var x in cartList)
            return getAllCartByBookType;
        }
    }
}
