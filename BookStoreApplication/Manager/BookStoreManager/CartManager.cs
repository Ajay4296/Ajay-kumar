using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using Repository.Repository;

namespace Manager.Manager
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public Task<int> AddCart(CartModel cartModel)
        {
            return cartRepository.AddCart(cartModel);
        }

        public CartModel DeleteCart(int id)
        {
            return cartRepository.DeleteCart(id);
        }

        public int CountCart()
        {
            return cartRepository.CountCart();
        }
    }
}
