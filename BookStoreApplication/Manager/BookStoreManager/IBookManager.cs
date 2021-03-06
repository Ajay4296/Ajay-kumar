﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Model;

namespace Manager
{
    /// <summary>
    /// IBookManager interface
    /// </summary>
    public interface IBookManager
    {
        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BookStoreModel> GetBooks();

        /// <summary>
        /// Adds the books detail.
        /// </summary>
        /// <param name="bookStoreModel">The book store model.</param>
        /// <returns></returns>
        int AddBooks(BookStoreModel bookStoreModel);

        /// <summary>
        /// Counts the book.
        /// </summary>
        /// <returns></returns>
       int CountBook();

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
      //  string Image(IFormFile file, int id);
    }
}
