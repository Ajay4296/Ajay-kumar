using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
   public  interface IBookRepository
    {
        IEnumerable<BookStoreModel> GetALLBooks();

        // int CountBook();
        Task<int> AddBooksDetail(BookStoreModel bookStoreModel);
    }
}
