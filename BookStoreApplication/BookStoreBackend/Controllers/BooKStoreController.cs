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
    /// <summary>
    /// Bookstore controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        /// <summary>
        /// The book manager
        /// </summary>
        private readonly IBookManager bookManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreController"/> class.
        /// </summary>
        /// <param name="bookManager">The book manager.</param>
        public BookStoreController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        [Route("GetALLBooks")]
        [HttpGet]
        public IEnumerable<BookStoreModel> GetALLBooks()
        {
            return bookManager.GetALLBooks();
        }

        /// <summary>
        /// Adds the book details.
        /// </summary>
        /// <param name="bookStoreModel">The book store model.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Counts the book.
        /// </summary>
        /// <returns></returns>
        [Route("CountBook")]
        [HttpGet]
        public int CountBook()
        {
            return bookManager.CountBook();

        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("Image")]
        [HttpPost]
        public string Image(IFormFile file, int id)
        {
            return bookManager.Image(file,id);
        }
    }
}