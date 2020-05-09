using BookStoreBackend.Controllers;
using Manager;
using Manager.AddressManager;
using Manager.Manager;
using Model;
using Model.Model;
using Moq;
using NUnit.Framework;
using Repository;
using Repository.AddressRepository;
using Repository.DBContext;
using Repository.Repository;
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
        /// <summary>
        /// invoking controller AddBook method with mock for bookmanager interface and testing return type 
        /// </summary>
        [Test]
        public void GivenController_AddBook_Method_Should_Return_Data()
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
            var data = controller.AddBookDetails(book);
            Assert.IsNotNull(data);
        }
        /// <summary>
        /// invkoing manager class addbook method and with parameter  repository intereface  to using mock as instance interface implemneted class 
        /// </summary>
        [Test]
        public void GivenManager_AddBook_Method_Should_Return_Data()
        {
            var service = new Mock<IBookRepository>();
            var manager = new BookManager(service.Object);
            book.BookID = 1;
            book.AuthorName = "Ravindhar";
            book.BookTittle = "My LifeStyle";
            book.BookCount = 1;
            book.Summary = "this book is written to expose my biography";
            book.Price = 400;
            book.BookImage = "img.jpg";
            var data = manager.AddBooksDetail(book);
            Assert.IsNotNull(data);
        }
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
        /// <summary>
        /// invoking the Getallbooks method from BookRepository class which implements repositroy interface
        /// </summary>
        [Test]
        public void GivenManager_GetAllBooks_Method_ShouldReturn_Data()
        {
            var service = new Mock<IBookRepository>();
            var manager = new BookManager(service.Object); ;
            var data = manager.GetALLBooks();
            Assert.IsNotNull(data);
        }
        /// <summary>
        /// invoking the countbook method from  controller class with arguments  Ibookmanger interface 
        /// is implemented by bookmanger class
        /// </summary>
        [Test]
        public void GivenController_ConutBook_Method_ShouldReturn_Count()
        {
            var service = new Mock<IBookManager>();
            var controller = new BookStoreController(service.Object);
            var count = controller.CountBook();
            Assert.IsNotNull(count);
        }
        /// <summary>
        ///invoking the countbook method from manager class with arguments Ibookrepository interface
        /// is implemented by bookmanger class
        /// </summary>
        [Test]
        public void GivenManager_CountBook_Method_ShouldReturn_Count()
        {
            var service = new Mock<IBookRepository>();
            var manager = new BookManager(service.Object);
            var count = manager.CountBook();
            Assert.IsNotNull(count);
        }
        /// <summary>
        ///invoking the addcart method from manager class with arguments Icartrepository interface
        /// is implemented by cartrepository class
        /// </summary>
        [Test]
        public void GivenCartManager_AddCart_Method_ShouldReturn_Data()
        {
            CartModel cartmodel = new CartModel();
            cartmodel.CartID = 1;
            cartmodel.Cart = new BookStoreModel();
            var service = new Mock<ICartRepository>();
            var cartmanager = new CartManager(service.Object);
            var data = cartmanager.AddCart(cartmodel);
            Assert.IsNotNull(data);
        }
        /// <summary>
        ///invoking the deletecart method from cartmanager class with arguments Icartrepository interface
        /// is implemented by cartrepository  class
        /// </summary>
        [Test]
        public void GivenCartManager_DeleteCart_Method_ShouldReturn_Output()
        {
            CartModel cartmodel = new CartModel();
            cartmodel.CartID = 1;
            cartmodel.Cart = new BookStoreModel();
            var service = new Mock<ICartRepository>();
            var cartmanager = new CartManager(service.Object);
            var data = cartmanager.DeleteCart(cartmodel.CartID);
            Assert.Null(data);
        }
        /// <summary>
        /// invoking the getaddress method  from i addressmanager class with arguments Iaddresrepository interface is implemented by
        /// address classs
        /// </summary>
        [Test]
        public void GivenAddressManager_GetAddress_Method_ShouldReturn_Data()
        {
            var service = new Mock<IAddressRepository>();
            var addressmanager = new ProductAddressManager(service.Object);
            var data = addressmanager.GetAddress();
            Assert.IsNotNull(data);
        }
        /// <summary>
        ///invoking the add detail  
        /// </summary>
        [Test]
        public void GivenAddressManager_AddDetailAddress_Method_ShouldReturn_Data()
        {
            AddressModel addressmodel = new AddressModel();
            addressmodel.BookID = 1;
            addressmodel.CityTown = "khammam";
            addressmodel.ContactNumber = 9505012267;
            addressmodel.deliveryAddress = "kusumanchi";
            addressmodel.Email = "nalagatiravindghar@gmail.com";
            addressmodel.FullName = "Nalagati Ravindhar";
            addressmodel.ZipCode = 507159;
            addressmodel.LandMark = "oppo police station";
            var service = new Mock<IAddressRepository>();
            var addressmanager = new ProductAddressManager(service.Object);
            var data = addressmanager.AddDetailAddress(addressmodel);
            Assert.IsNotNull(data);
        }
        /// <summary>
        ///invoking the getaddress method from addresscontroller class with arguments Iaddressmanager repository which will get instance 
        /// </summary>
        [Test]
        public void GivenAddressController_GetAddress_Method_ShouldReturn_Data()
        {
            var service = new Mock<IAddressManager>();
            var addresscontroller = new AddressController(service.Object);
            var data = addresscontroller.GetAddress();
        }
        /// <summary>
        /// invoking the adddetailaddress method from addresscontroller  class with arguements Addreesmodel class
        /// </summary>
        [Test]
        public void GivenAddressController_AddDetailAddress_Method_ShouldReturn_Data()
        {
            AddressModel addressmodel = new AddressModel();
            addressmodel.BookID = 1;
            addressmodel.CityTown = "khammam";
            addressmodel.ContactNumber = 9505012267;
            addressmodel.deliveryAddress = "kusumanchi";
            addressmodel.Email = "nalagatiravindghar@gmail.com";
            addressmodel.FullName = "Nalagati Ravindhar";
            addressmodel.ZipCode = 507159;
            addressmodel.LandMark = "oppo police station";
            var service = new Mock<IAddressManager>();
            var addresscontroller = new AddressController(service.Object);
            var data = addresscontroller.AddDetailAddreess(addressmodel);
            Assert.IsNotNull(data);
        }
    }
}
