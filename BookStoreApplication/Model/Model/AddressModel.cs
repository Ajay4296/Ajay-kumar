using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Model
{
   public class AddressModel
    {
        [Key]        
        public string Email { get; set; }
       
        public string FullName { get; set; }
 
        public string ContactNumber { get; set; }
       
        public string DeliveryAddress { get; set; }

        public string ZipCode { get; set; }
        
        public string CityTown { get; set; }

        public string LandMark { get; set; }    

        public string AddressType { get; set; }
    }
}
 