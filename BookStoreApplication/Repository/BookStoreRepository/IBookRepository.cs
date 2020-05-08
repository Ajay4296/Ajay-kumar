using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repository
{
   public  interface IBookRepository
    {
        IEnumerable<BookStoreModel> GetALLBooks();
       int CountBook();
    }
}
