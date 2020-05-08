using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using Repository.DBContext;

namespace Repository.Repository
{
    public class CartRepository : ICartRepositorycs
    {
        private readonly UserDbContext userDbContext;

        public Task<int> AddCart(CartModel cartModel)
        {
            userDbContext.CartTable.Add(cartModel);
            var result = userDbContext.SaveChangesAsync();
            return result;
        }
    }
}
