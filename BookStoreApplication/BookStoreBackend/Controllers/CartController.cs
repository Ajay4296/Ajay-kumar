using System;
using System.Linq;
using System.Threading.Tasks;
using Manager.Manager;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace BookStoreBackend.Controllers
{
    /// <summary>
    /// Cart controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        /// <summary>
        /// The cart manager
        /// </summary>
        private readonly ICartManager CartManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController"/> class.
        /// </summary>
        /// <param name="CartManager">The cart manager.</param>
        public CartController(ICartManager CartManager)
        {
            this.CartManager = CartManager;
        }

        /// <summary>
        /// Adds the cart.
        /// </summary>
        /// <param name="cartModel">The cart model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[Route("AddCart")]
        [HttpPost]
        public async Task<IActionResult> AddCart(CartModel cartModel)
        {
            try
            {
                var result = await this.CartManager.AddCart(cartModel);
                if (result == 1)
                {
                    return this.Ok(cartModel);
                }
                else
                {
                    return this.BadRequest();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        /// <summary>
        /// Deletes the cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        //[Route("DeleteCart")]
        [HttpDelete]
        public CartModel DeleteCart(int id)
        {
            return CartManager.DeleteCart(id);
        }

        /// <summary>
        /// Counts the cart.
        /// </summary>
        /// <returns></returns>
        [Route("GetCount")]
        [HttpGet]
        public int CountCart()
        {
            return CartManager.CountCart();
        }

        /// <summary>
        /// Gets all cart value.
        /// </summary>
        /// <returns></returns>
       // [Route("")]
        [HttpGet]
        public IQueryable GetAllCartValue()
        {
            return CartManager.GetAllCartValue();
        }
    }
}