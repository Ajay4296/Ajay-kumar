using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Model;
using Repository.Repository;

namespace Manager.Manager
{
    /// <summary>
    /// implementation of ICartManager interface
    /// </summary>
    /// <seealso cref="Manager.Manager.ICartManager" />
    public class CartManager : ICartManager
    {
        /// <summary>
        /// The cart repository
        /// </summary>
        private readonly ICartRepository cartRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartManager"/> class.
        /// </summary>
        /// <param name="cartRepository">The cart repository.</param>
        public CartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        /// <summary>
        /// Adds the cart.
        /// </summary>
        /// <param name="cartModel">The cart model.</param>
        /// <returns></returns>
        public int AddCart(CartModel cartModel)
        {
            return cartRepository.AddCart(cartModel);
        }

        /// <summary>
        /// Deletes the cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
       public string DeleteCart(int id)
        {
            return cartRepository.DeleteCart(id);
        }

        /// <summary>
        /// Counts the cart.
        /// </summary>
        /// <returns></returns>
        public int CountCart()
        {
            return cartRepository.CartCount();
        }

        /// <summary>
        /// Gets all cart value.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookStoreModel> GetCart()
        {
            return cartRepository.GetCart();
        }
    }
}
