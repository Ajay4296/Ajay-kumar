using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Model;

namespace Repository
{
  
    public interface IBookRepository
    {
        
        IEnumerable<BookStoreModel> GetBooks();

        int AddBooks(BookStoreModel bookStoreModel);

       int CountBook();
       // string Image(IFormFile file, int id);
    }
}
