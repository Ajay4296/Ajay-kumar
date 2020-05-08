﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository.DBContext;

namespace Repository
{
    public class BookRepository:IBookRepository
    {
        private readonly UserDbContext userDBContext;
      
        public BookRepository(UserDbContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }

        public int CountBook()
        {
            
           var result=userDBContext.BookStore.ToList();
            return result.Count;

        }

        IEnumerable<BookStoreModel> IBookRepository.GetALLBooks()
        {
            return userDBContext.BookStore;
        }
        public Task<int> AddBooksDetail(BookStoreModel bookStoreModel)
        {
            userDBContext.BookStore.Add(bookStoreModel);
            var result = userDBContext.SaveChangesAsync();
            return result;
        }
    }
}
