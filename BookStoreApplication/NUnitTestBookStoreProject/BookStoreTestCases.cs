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
    /// <summary>
    /// Test class
    /// </summary>
    public class BookStoreTestCases
    {
        readonly BookStoreModel book = new BookStoreModel();
        private readonly string email;
      
        /// <summary>
        /// invoking controller AddBook method with mock for bookmanager interface and testing return type 
        /// </summary>
        [Test]
        public void GivenBookDetails_WhenPassedToBookController_ShouldReturnBookAdded()
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
        public void GivenBookDetails_WhenPassedToBookManager_ShouldReturnBookAdded()
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
        public void GivenGetAllBooks_WhenPassedToBookController_ShouldReturnBooksDetails()
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
        public void GivenGetAllBooks_WhenPassedToBookManager_ShouldReturnBooksDetails()
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
        public void GivenCountBook_WhenPassedToBookController_ShouldReturnBooksCount()
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
        public void GivenCountBook_WhenPassedToBookManager_ShouldReturnBooksCount()
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
        public void GivenAddCart_WhenPassedToCartManager_ShouldReturnAddedCart()
        {
            CartModel cartmodel = new CartModel();
            cartmodel.CartID = 1;
            cartmodel.Book_ID = 001;
            cartmodel.SelectBookCount = 2;
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
        public void GivenDelete_WhenPassedToCartManager_ShouldReturnDeletedCart()
        {
            CartModel cartmodel = new CartModel();
            cartmodel.CartID = 1;
            cartmodel.Book_ID = 001;
            cartmodel.SelectBookCount = 2;
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
        public void GivenGetAddress_WhenPassedToProductAddressManager_ShouldReturnGetAddress()
        {
            var service = new Mock<IAddressRepository>();
            var addressmanager = new ProductAddressManager(service.Object);
            var data = addressmanager.GetCustomerAddress(email);
            Assert.IsNotNull(data);
        }

        /// <summary>
        ///invoking the add detail  method from repository class 
        /// </summary>
        [Test]
        public void GivenAddDetailAddress_WhenPassedToProductAddressManager_ShouldReturnGetDetailAddress()
        {
            AddressModel addressmodel = new AddressModel();
            addressmodel.CityTown = "khammam";
            addressmodel.ContactNumber = "9505012267";
            addressmodel.Email = "nalagatiravindghar@gmail.com";
            addressmodel.FullName = "Nalagati Ravindhar";
            addressmodel.ZipCode = "507159";
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
        public void GivenGetAddress_WhenPassedToAddressController_ShouldReturnGetAddress()
        {
            var service = new Mock<IAddressManager>();
            var addresscontroller = new AddressController(service.Object);
            var data = addresscontroller.GetCustomerAddress(email);
        }

        /// <summary>
        /// invoking the adddetailaddress method from addresscontroller  class with arguements Addreesmodel class
        /// </summary>
        [Test]
        public void GivenAddDetail_WhenPassedToProductAddressController_ShouldReturnAddedAddressDetails()
        {
            AddressModel addressmodel = new AddressModel();
            addressmodel.CityTown = "khammam";
            addressmodel.ContactNumber = "9505012267";
            addressmodel.Email = "nalagatiravindghar@gmail.com";
            addressmodel.FullName = "Nalagati Ravindhar";
            addressmodel.ZipCode = "507159";
            addressmodel.LandMark = "oppo police station";           
            var service = new Mock<IAddressManager>();
            var addresscontroller = new AddressController(service.Object);
            var data = addresscontroller.AddDetailAddreess(addressmodel);
            Assert.IsNotNull(data);
        }
    }
}
