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
        private readonly ICartManager bookManager;

        public CartController(ICartManager bookManager)
        {
            this.bookManager = bookManager;
        }


        [Route("AddCart")]
        [HttpPost]
        public async Task<IActionResult> AddCart(CartModel cartModel)
        {
            var result = await this.bookManager.AddCart(cartModel); 
            if (result == 1)
            {
                return this.Ok(cartModel);
            }
            else
            {
                return this.BadRequest();
            }

        }
    }
}