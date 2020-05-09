using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public int CountBook()
        {
            return bookRepository.CountBook();
        }

        public IEnumerable<BookStoreModel> GetALLBooks()
        {
            return bookRepository.GetALLBooks();
        }
        public Task<int> AddBooksDetail(BookStoreModel bookStoreModel)
        {
            return this.bookRepository.AddBooksDetail(bookStoreModel);
        }

        public string Image(IFormFile file, int id)
        {
            return bookRepository.Image(file,id);
        }
    }
}
