using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Model;
using Repository.Common;
using static Repository.Common.BookStoreException;

namespace BookStoreBackend.Controllers
{
    /// <summary>
    /// Cart controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// 
    [Authorize]
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

        [HttpPost]
        public  IActionResult AddCart(CartModel cartModel)
        { 
                var result = CartManager.AddCart(cartModel);
            try
            {
                if (result == 0)
                {

                    return this.BadRequest();

                }
                return this.Ok(cartModel);
            }
            catch (BookStoreException)
            {
                return BadRequest(Exception_type.Invalid_exception.ToString());
            }
        }
        
       [HttpDelete]
        public string DeleteCart(int id)
        {
            return CartManager.DeleteCart(id);
        }

        [Route("CountCart")]
        [HttpGet]
        public int CountCart()
        {
            return CartManager.CountCart();
        }

        [HttpGet]
        public IEnumerable<BookStoreModel> GetCart()
        {
            return CartManager.GetCart();
        }
    }
}