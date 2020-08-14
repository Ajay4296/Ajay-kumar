using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreRepositoryLayer.Common;
using BookStoreRepositoryLayer.JsonErrorHandler;
using Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Model;
using Newtonsoft.Json;
using Repository.Common;
using static Repository.Common.BookStoreException;

namespace BookStoreBackend.Controllers
{
    /// <summary>
    /// Bookstore controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    
     [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
       
        private readonly IBookManager bookManager;
        private readonly ILogger logger;
        public readonly IDistributedCache distributedCache;
        public string key = "book";

        public BookStoreController(IBookManager bookManager, IDistributedCache distributedCache, ILoggerFactory factory)
        {
            this.bookManager = bookManager;
            this.distributedCache = distributedCache;
            this.logger = factory.CreateLogger("BookCategory");
        }
        MSMQ msmq = new MSMQ();

        [HttpGet]
        public IEnumerable<BookStoreModel> GetBooks()
        {
            logger.LogInformation("Get All Book Detail");
            var cache = this.distributedCache.GetString(key);
            if (cache == null)
            {
                var result = this.bookManager.GetBooks();
                if (result != null)
                {
                    var jsonmodel = JsonConvert.SerializeObject(result);
                    this.distributedCache.SetString(key, jsonmodel);
                    return result;
                }
                else
                {
                    return (IEnumerable<BookStoreModel>)NotFound();
                }
            }
            else
            {
                var model = JsonConvert.DeserializeObject<List<BookStoreModel>>(cache);
                return model;
            }
        }

        [HttpPost]
        public IActionResult AddBooks(BookStoreModel bookStoreModel)
        {
            var result = bookManager.AddBooks(bookStoreModel);
            try
            {
                if (result == 1)
                {
                    this.distributedCache.Remove(key);
                    msmq.SendMessage("Books name " + bookStoreModel.BookTittle + " added successfully.", result);
                    return this.Ok(bookStoreModel);
                }
                else
                {
                    return this.BadRequest(JsonErrorModel.Json());
                }
            }
            catch(BookStoreException)
            {
                return BadRequest(Exception_type.Invalid_exception.ToString());
            }
               }

        [Route("CountBook")]
        [HttpGet]
        public int CountBook()
        {
            logger.LogInformation("Get Number of Books");
            return bookManager.CountBook();
        }
    
    }
} 