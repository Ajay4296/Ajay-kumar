using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Model;
using Repository.DBContext;

namespace Repository.Repository
{
    /// <summary>
    /// implementstion of ICartRepository interface
    /// </summary>
    /// <seealso cref="Repository.Repository.ICartRepository" />
    public class CartRepository : ICartRepository
    {
        /// <summary>
        /// The user database context
        /// </summary>
        private readonly UserDbContext userDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartRepository"/> class.
        /// </summary>
        /// <param name="userDbContext">The user database context.</param>
        public CartRepository(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        /// <summary>
        /// Adds the cart.
        /// </summary>
        /// <param name="cartModel">The cart model.</param>
        /// <returns></returns>
        public Task<int> AddCart(CartModel cartModel)
        {
            userDbContext.CartTable.Add(cartModel);
            var result = userDbContext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Deletes the cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CartModel DeleteCart(int id)
        {
           CartModel cartModel= userDbContext.CartTable.Find(id);
            if (cartModel != null)
            {
                userDbContext.CartTable.Remove(cartModel);
                userDbContext.SaveChanges();
            }
            return cartModel;
        }

        /// <summary>
        /// Counts the cart.
        /// </summary>
        /// <returns></returns>
        public int CountCart()
        {
            var result = userDbContext.CartTable.ToList();
            return result.Count;
        }

        /// <summary>
        /// Gets all cart value.
        /// </summary>
        /// <returns></returns>
        public IQueryable GetAllCartValue()
        {
            var result = this.userDbContext.CartTable.Join(this.userDbContext.BookStore,
                Cart => Cart.Book_ID,
                Book => Book.BookID,
                (Cart, Book) =>
                new
                {
                    cartID = Cart.CartID,
                    bookId = Book.BookID,
                    bookTitle = Book.BookTittle,
                    authorName = Book.AuthorName,
                    bookImage = Book.BookImage,
                    bookPrice = Book.Price,
                    numOfCopies = Cart.SelectBookCount
                });
            return result;
        }
    }
}
