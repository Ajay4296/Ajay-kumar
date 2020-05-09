using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Model;

namespace Repository
{
    public interface IBookRepository
    {
        IEnumerable<BookStoreModel> GetALLBooks();

        Task<int> AddBooksDetail(BookStoreModel bookStoreModel);

        int CountBook();

        string Image(IFormFile file, int id);
    }
}
