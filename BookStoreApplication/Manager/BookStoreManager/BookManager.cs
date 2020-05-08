using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Manager
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository bookRepository;
        public BookManager(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }


        public IEnumerable<BookStoreModel> GetALLBooks()
        {
            return bookRepository.GetALLBooks();
        }
        public Task<int> AddBooksDetail(BookStoreModel bookStoreModel)
        {
            return this.bookRepository.AddBooksDetail(bookStoreModel);
        }
    }
}
