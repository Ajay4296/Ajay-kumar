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
<<<<<<< HEAD
        
        [Required]
        public double ContactNumber { get; set; }
        [Required]
        public string Password { get; set; }     
        [Required]
        public string FullName { get; set; }
 
        [Required]
=======
       
        public string FullName { get; set; }
 
        public string ContactNumber { get; set; }
       
>>>>>>> 96ab52cb3f712c36f10e3c591378abfaa324a4f0
        public string DeliveryAddress { get; set; }

        public string ZipCode { get; set; }
        
        public string CityTown { get; set; }

        public string LandMark { get; set; }    

        public string AddressType { get; set; }
    }
}
 