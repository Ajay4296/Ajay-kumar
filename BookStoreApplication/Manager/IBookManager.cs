using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Manager
{
    public interface IBookManager
    {
        IEnumerable<BookStoreModel> GetALLBooks();
    }
}
