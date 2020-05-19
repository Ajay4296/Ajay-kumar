using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Model;

namespace Repository.DBContext
{
    /// <summary>
    /// This is a UserDBContext class which is interect with database
    /// It"s manage maintain database connection and used to retrive and save data from the database
    /// This class is inheritance DbContext which is a base class defined in the EF coreFreameWork
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class UserDbContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the book store.
        /// </summary>
        /// <value>
        /// The book store.
        /// </value>
        public DbSet<BookStoreModel> BookStore { get; set; }

        /// <summary>
        /// Gets or sets the cart table.
        /// </summary>
        /// <value>
        /// The cart table.
        /// </value>
        public DbSet<CartModel> CartTable { get; set; }

        /// <summary>
        /// Gets or sets the address space.
        /// </summary>
        /// <value>
        /// The address space.
        /// </value>
        public DbSet<AddressModel> AddressSpace { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }


    }
}
