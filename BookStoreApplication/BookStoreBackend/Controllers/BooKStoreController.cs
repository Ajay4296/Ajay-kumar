using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly IBookManager bookManager;

        public BookStoreController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        [Route("GetALLBooks")]
        [HttpGet]
        public IEnumerable<BookStoreModel> GetALLBooks()
        {
            return bookManager.GetALLBooks();
        }


        [Route("AddBookDetails")]
        [HttpPost]
        public async Task<IActionResult> AddBookDetails(BookStoreModel bookStoreModel)
        {
            var result = await this.bookManager.AddBooksDetail(bookStoreModel);
            if (result == 1)
            {
                return this.Ok(bookStoreModel);
            }
            else
            {
                return this.BadRequest();
            }
        }


        [Route("CountBook")]
        [HttpGet]
        public int CountBook()
        {
            return bookManager.CountBook();

        }

        [Route("Image")]
        [HttpPost]
        public string Image(IFormFile file, int id)
        {
            return bookManager.Image(file,id);
        }
    }
}