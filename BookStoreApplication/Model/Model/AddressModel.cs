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
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        
        [Required]
        public int ContactNumber { get; set; }

        

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string CityTown { get; set; }

        [Required]
        public string LandMark { get; set; }
    }
}
 