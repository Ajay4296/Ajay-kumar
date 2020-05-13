using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Common
{
    public class BookStoreException : Exception
    {
        public BookStoreException(string message) : base(message)
        {
        }
    }
}
