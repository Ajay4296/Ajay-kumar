using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <summary>
        /// Adds the cart.
        /// </summary>
        /// <param name="cartModel">The cart model.</param>
        /// <returns></returns>
        Task<int> AddCart(CartModel cartModel);

        /// <summary>
        /// Deletes the cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        CartModel DeleteCart(int id);

        /// <summary>
        /// Counts the cart.
        /// </summary>
        /// <returns></returns>
        int CountCart();

        /// <summary>
        /// Gets all cart value.
        /// </summary>
        /// <returns></returns>
        IQueryable GetAllCartValue();

    }
}
