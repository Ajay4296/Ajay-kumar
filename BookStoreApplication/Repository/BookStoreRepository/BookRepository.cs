using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Services.Account;
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
        public string Image(IFormFile file, int id)
        {
            if (file == null)
            {
                return "Empty";
            }
            var stream = file.OpenReadStream();
            var name = file.FileName;
            Account account = new Account("dwjxrmuuw", "928598494955297", "Wc0AgzT1uvQyl-0-xx5S0AzJtZo");
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
            };
            ImageUploadResult UploadResult = cloudinary.Upload(uploadParams);
            cloudinary.Api.ApiUrlImgUp.BuildUrl(String.Format("{0}.{1}", UploadResult.PublicId, UploadResult.Format));
            var data = this.userDBContext.Book.Where(t => t.BookID == id).FirstOrDefault();
            data.BookImage = UploadResult.Uri.ToString();
            try
            {
                var result = this.userDBContext.SaveChanges();
                return data.BookImage;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
