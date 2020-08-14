using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Model.Model;

namespace Repository.AddressRepository
{

    public class ProductAddressRepository : IAddressRepository
    {
        private readonly IConfiguration configuration;
        public ProductAddressRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void  Addaddress(AddressModel addressModel)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("ADDRESS", con);
                cmd.CommandType = CommandType.StoredProcedure;
               ///cmd.Parameters.AddWithValue("@ADDRESS", addressModel.AddressModelID);
                cmd.Parameters.AddWithValue("@NAME", addressModel.FullName);
                cmd.Parameters.AddWithValue("@EMAIL", addressModel.Email);
                cmd.Parameters.AddWithValue("@DELIVERYaDDRESS", addressModel.DeliveryAddress);
                cmd.Parameters.AddWithValue("@PIN", addressModel.ZipCode);
                cmd.Parameters.AddWithValue("@PHONENUM", addressModel.ContactNumber);
                con.Open();
              int row =  cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<AddressModel> GetAllAddress()
        {
            List<AddressModel> addresses = new List<AddressModel>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:UserDbConnection"]))
            {
                SqlCommand cmd = new SqlCommand("GetAllAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AddressModel addressModel = new AddressModel();
                    addressModel.AddressModelID = Convert.ToInt32(rdr["ADDRESSID"]);
                   addressModel.FullName = rdr["NAME"].ToString();
                   addressModel.Email = rdr["EMAIL"].ToString();
                   addressModel.DeliveryAddress = rdr["DELIVERYADDRESS"].ToString();
                   addressModel.ZipCode = Convert.ToInt32(rdr["PIN"]);
                    addressModel.ContactNumber = Convert.ToInt32(rdr["PHONENUM"]);
                    addresses.Add(addressModel);
                }
                con.Close();
            }
            return addresses;
        }
    }
}
