using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
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
            try
            {
                if (file == null)
            {
                return "Empty";
            }
            var stream = file.OpenReadStream();
            var name = file.FileName;

            Account account = new Account("dwfuzvg7h", "335663819648742", "BKYXockUt0Hs_3Vs5BIQBG2JK6o");

            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
            };

            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
            cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
            //var data = this.userDBContext.Items.Where(t => t.ItemId == id).FirstOrDefault();
            var data = this.userDBContext.BookStore.Where(book=>book.BookID == id).FirstOrDefault();
            data.BookImage = uploadResult.Uri.ToString();

            
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
