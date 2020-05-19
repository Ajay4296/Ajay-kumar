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
    /// <summary>
    /// Implementation of 
    /// </summary>
    /// <seealso cref="Repository.IBookRepository" />
    public class BookRepository:IBookRepository
    {
        /// <summary>
        /// The user database context
        /// </summary>
        private readonly UserDbContext userDBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="userDBContext">The user database context.</param>
        public BookRepository(UserDbContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }

        /// <summary>
        /// Counts the book.
        /// </summary>
        /// <returns></returns>
        public int CountBook()
        {
            var result = userDBContext.BookStore.ToList();
            return result.Count;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BookStoreModel> IBookRepository.GetALLBooks()
        {
            return userDBContext.BookStore;
        }

        /// <summary>
        /// Adds the books detail.
        /// </summary>
        /// <param name="bookStoreModel">The book store model.</param>
        /// <returns></returns>
        public Task<int> AddBooksDetail(BookStoreModel bookStoreModel)
        {
            userDBContext.BookStore.Add(bookStoreModel);
            var result = userDBContext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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
                
                var data = this.userDBContext.BookStore.Where(book => book.BookID == id).FirstOrDefault();
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
