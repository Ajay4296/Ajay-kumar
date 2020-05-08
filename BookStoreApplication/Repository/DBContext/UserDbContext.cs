using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Model;

namespace Repository.DBContext
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        
        public DbSet<BookStoreModel> BookStore { get; set; }
        public DbSet<CartModel> CartTable { get; set; }
        public DbSet<AddressModel> AddressSpace { get; set; }


    }
}
