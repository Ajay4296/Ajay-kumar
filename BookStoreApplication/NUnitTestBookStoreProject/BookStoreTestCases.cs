using BookStoreBackend.Controllers;
using Manager;
using Model;
using Moq;
using NUnit.Framework;
using Repository;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NUnitTestBookStoreProject
{
    public class Tests
    {
        BookStoreModel book = new BookStoreModel();
        [SetUp]
        public void Setup()
        {
        }

        /* [Test]
         public void GivenController_Api_Should_Return_Data()
         {
             var service = new Mock<IBookManager>();
             var controller = new BookStoreController(service.Object);
             book.BookID = 1;
             book.AuthorName = "Ravindhar";
             book.BookTittle = "My LifeStyle";
             book.BookCount = 1;
             book.Summary = "this book is written to expose my biography";
             book.Price = 400;
             book.BookImage = "img.jpg";
         }*/
        /// <summary>
        /// Given instance and checking the API in controller for GetALLBooks() method 
        /// testing return value is not null
        /// </summary>
        [Test]
        public void GivenController_GetAllBooks_Method_ShouldReturn_Data()
        {
            var service = new Mock<IBookManager>();
            var controller = new BookStoreController(service.Object);
            var data = controller.GetALLBooks();
            Assert.IsNotNull(data);
        }
        [Test]
        public void GivenManager_GetAllBooks_Method_ShouldReturn_Data()
        {
            var service = new Mock<IBookRepository>();
            var manager = new BookManager(service.Object); ;
            var data = manager.GetALLBooks();
            Assert.IsNotNull(data);
        }
        [Test]
        public void GivenController_ConutBook_Method_ShouldReturn_Count()
        {
            var service = new Mock<IBookManager>();
            var controller = new BookStoreController(service.Object);
            var count = controller.CountBook();
            Assert.IsNotNull(count);
        }
        [Test]
        public void GivenManager_CountBook_Method_ShouldReturn_Count()
        {
            var service = new Mock<IBookRepository>();
            var manager = new BookManager(service.Object);
            var count = manager.CountBook();
            Assert.IsNotNull(count);
        }
        
    }
    }
