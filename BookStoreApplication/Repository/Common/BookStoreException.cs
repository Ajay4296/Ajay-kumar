using System;

namespace Repository.Common
{
    /// <summary>
    /// custom exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class BookStoreException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BookStoreException(string message) : base(message)
        {
        }
    }
}
