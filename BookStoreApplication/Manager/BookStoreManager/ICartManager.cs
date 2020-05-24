﻿using System.Linq;
using System.Threading.Tasks;
using Model.Model;

namespace Manager.Manager
{
    /// <summary>
    /// Interface class of ICartManager
    /// </summary>
    public interface ICartManager
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
