using BookStoreRepositoryLayer.Common;
using Microsoft.Extensions.Configuration;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Registratoin
{
   public class RegistrationRepo :IRegistrationRepo
    {

        private readonly IConfiguration configuration;

        public RegistrationRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<Registration> GetRegistrations()
        {
            List<Registration> list = new List<Registration>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("GetAllRegistration   ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Registration register = new Registration();
                    register.UserRegistrationID = Convert.ToInt32(rdr["UserRegistrationID"]);
                    register.Name = rdr["Name"].ToString();
                    register.Email = rdr["Email"].ToString();
                    register.Password = rdr["Password"].ToString();
                    list.Add(register);
                }
                con.Close();
            }
            return list;
        }

        //To Add new employee record    
        public int AddRegistration(Registration register)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("AddRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", register.Name);
                cmd.Parameters.AddWithValue("@Email", register.Email);
           //    register.Password = PasswordEncodeAndDecode.base64Encode(register.Password);
                cmd.Parameters.AddWithValue("@Password", register.Password);
                con.Open();
             int row  = cmd.ExecuteNonQuery();
                con.Close();
                return row;
            }
        }
        public int Login(string Email,string Password)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email",Email);
          //  Password = PasswordEncodeAndDecode.base64Encode(Password);
                cmd.Parameters.AddWithValue("@Password",Password);
                con.Open();
                 var count= (int)cmd.ExecuteScalar();
                con.Close();
                return count; 
            }
        }
    }
}
