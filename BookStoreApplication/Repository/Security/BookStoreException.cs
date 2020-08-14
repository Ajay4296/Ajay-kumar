using System;

namespace Repository.Common
{
   
    public class BookStoreException : Exception
    {
        public enum Exception_type
        {
            Null_Exception,
            Empty_Exception,
            Invalid_exception
        }
        public BookStoreException(string message) : base(message)
        {

        }
    }
}
