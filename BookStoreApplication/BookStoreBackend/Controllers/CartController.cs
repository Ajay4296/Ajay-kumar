using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager;
using Manager.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager CartManager;

        public CartController(ICartManager CartManager)
        {
            this.CartManager = CartManager;
        }

         
        [Route("AddCart")]
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

            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }

        [Route("DeleteCart")]
        [HttpDelete]
        public CartModel DeleteCart(int id)
        {
            return CartManager.DeleteCart(id);
        }

        [Route("CountCart")]
        [HttpGet]
        public int CountCart()
        {
            return CartManager.CountCart();
        }
    }
}