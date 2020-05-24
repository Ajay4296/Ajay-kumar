using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Model;
using Repository;

namespace Manager
{
    /// <summary>
    /// Implementation of the BookManager interface
    /// </summary>
    /// <seealso cref="Manager.IBookManager" />
    public class BookManager : IBookManager
    {
        /// <summary>
        /// The book repository
        /// </summary>
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookManager"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public BookManager(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <summary>
        /// Counts the book.
        /// </summary>
        /// <returns></returns>
        public int CountBook()
        {
            return bookRepository.CountBook();
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookStoreModel> GetALLBooks()
        {
            return bookRepository.GetALLBooks();
        }

        /// <summary>
        /// Adds the books detail.
        /// </summary>
        /// <param name="bookStoreModel">The book store model.</param>
        /// <returns></returns>
        public Task<int> AddBooksDetail(BookStoreModel bookStoreModel)
        {
            return this.bookRepository.AddBooksDetail(bookStoreModel);
        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string Image(IFormFile file, int id)
        {
            return bookRepository.Image(file, id);
        }
    }
}
