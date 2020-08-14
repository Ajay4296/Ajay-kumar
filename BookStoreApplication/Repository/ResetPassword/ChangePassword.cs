using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepositoryLayer.ResetPassword
{
   public class ChangePassword : IChangePassword
    {
        private readonly IConfiguration configuration;

        public ChangePassword(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string PasswordChange(string Email, string OldPassword,string NewPassword)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("UserChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@oldPassword", OldPassword);
                cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "SuccessFully changed Password";
            }
        }
    }
}
