using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IBookManager bookManager;

        public CartController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        [Route("AddCart")]
        [HttpPost]
        public Task<IActionResult> AddCart(IBookManager bookManager)
        {
            return bookManager.
        }
    }
}