using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
