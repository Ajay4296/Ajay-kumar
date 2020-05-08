using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Model;

namespace Manager
{
    public interface IBookManager
    {
        IEnumerable<BookStoreModel> GetALLBooks();

        Task<int> AddBooksDetail(BookStoreModel bookStoreModel);

        int CountBook();
    }
}
