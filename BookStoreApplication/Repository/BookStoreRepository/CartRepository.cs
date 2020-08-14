using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Model; 

namespace Repository.Repository
{
    public class CartRepository : ICartRepository
    {
        // string connectionString = "Server=(localdb)\\MSSQLLocalDB;database=BOOKSTOREDATABASE;Trusted_Connection=True";
        private readonly IConfiguration configuration;
        public CartRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public int AddCart(CartModel cartModel)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("AddCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", cartModel.BookID);
                cmd.Parameters.AddWithValue("@CountCart", cartModel.SelectBookCount);
                con.Open();
             int row =  cmd.ExecuteNonQuery(); 
                con.Close();
                return row;
            }
        }
        public IEnumerable<BookStoreModel> GetCart()
        {
            List<BookStoreModel> cartList = new List<BookStoreModel>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("GetCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BookStoreModel storeModel = new BookStoreModel();
                    storeModel.BookID = Convert.ToInt32(rdr["BookID"]);
                    storeModel.BookTittle = rdr["BookTittle"].ToString();
                   storeModel.AuthorName = rdr["AuthorName"].ToString();
                  storeModel.BookImage = rdr["BookImage"].ToString();
                   storeModel.Price = Convert.ToInt32(rdr["Price"]);
                    storeModel.Summary= rdr["Summary"].ToString();
                    storeModel.Price = Convert.ToInt32(rdr["Price"]);
                    cartList.Add(storeModel);
                }
                con.Close();
            }
            return cartList;
        }  
           
        public string DeleteCart(int id)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("DeleteCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@CartId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return "SuccessFully Deleted";
        }

        public int CartCount()
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("CountCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                return count;
            }
        }
    }
}
