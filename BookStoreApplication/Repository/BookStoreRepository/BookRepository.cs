using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Model;

namespace Repository
{
  
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration configuration;

        public BookRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    
        public int AddBooks(BookStoreModel storeModel)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"])) 
            { 
                SqlCommand cmd = new SqlCommand("AddBooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookTittle", storeModel.BookTittle);
                cmd.Parameters.AddWithValue("@AuthorName", storeModel.AuthorName);
                cmd.Parameters.AddWithValue("@Price", storeModel.Price);
                cmd.Parameters.AddWithValue("@Summary", storeModel.Summary);
                cmd.Parameters.AddWithValue("@BookImage", storeModel.BookImage);
                cmd.Parameters.AddWithValue("@BookCount", storeModel.BookCount);
                con.Open();
                int row = cmd.ExecuteNonQuery();
                con.Close();
                return row;
            }
        }
        public IEnumerable<BookStoreModel> GetBooks()
        {
            List<BookStoreModel> bookList = new List<BookStoreModel>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("GETBOOK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BookStoreModel bookStore = new BookStoreModel();
                    bookStore.BookID = Convert.ToInt32(rdr["BookID"]);
                    bookStore.BookTittle = rdr["BookTittle"].ToString();
                    bookStore.AuthorName = rdr["AuthorName"].ToString();
                    bookStore.Price = Convert.ToInt32(rdr["Price"]);
                    bookStore.BookImage = rdr["BookImage"].ToString();
                    bookStore.Summary = rdr["Summary"].ToString();
                    bookStore.BookCount = Convert.ToInt32(rdr["BookCount"]);
                   bookList.Add(bookStore);
                }
                con.Close();
            }
            return bookList;
        }
        public int CountBook()
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("CountBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                int count = (int)cmd.ExecuteScalar(); 
                con.Close();
                return count;
            }
        }
    }
}
