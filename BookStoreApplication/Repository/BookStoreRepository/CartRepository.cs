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
        List<BookStoreModel> GetAll_CartValue = new List<BookStoreModel>();
        List<CartModel> Cart_List = new List<CartModel>();

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

            Cart_List = userDbContext.CartTable.ToList();
            for (int i = 0; i < Cart_List.Count; i++)
            {
                GetAll_CartValue.Add(userDbContext.BookStore.Find(Cart_List[i].Book_ID));
            }            
            return GetAll_CartValue;
        }
    }
}
