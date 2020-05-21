using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CloudinaryDotNet.Actions;

namespace Model.Model
{
    /// <summary>
    /// Address model class
    /// </summary>
    public class AddressModel
    {
        /// <summary>
        /// Gets or sets the AddressModel  identifier.
        /// </summary>
        /// <value>
        /// The AddressModel identifier.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AddressModelID { get; set; }

        /// <summary>
        /// Gets or sets the Email 
        /// </summary>
        [Required(ErrorMessage = "Email cannot be empty")]        
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [Required(ErrorMessage = "FullName cannot be empty")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>
        /// The contact number.
        /// </value>
        [Required(ErrorMessage = "ContactNumber cannot be empty")]
        public string ContactNumber { get; set; }

        /// <summary>
        /// Gets or sets the delivery address.
        /// </summary>
        /// <value>
        /// The delivery address.
        /// </value>
        [Required(ErrorMessage = "DeliveryAddress cannot be empty")] 
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        [Required(ErrorMessage = "ZipCode cannot be empty")] 
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city town.
        /// </summary>
        /// <value>
        /// The city town.
        /// </value>
        [Required(ErrorMessage = "CityTown cannot be empty")] 
        public string CityTown { get; set; }

        /// <summary>
        /// Gets or sets the land mark.
        /// </summary>
        /// <value>
        /// The land mark.
        /// </value>
        [Required(ErrorMessage = "LandMark cannot be empty")]
        public string LandMark { get; set; }

        /// <summary>
        /// Gets or sets the type of the address.
        /// </summary>
        /// <value>
        /// The type of the address.
        /// </value>
        [Required(ErrorMessage = "AddressType cannot be empty")] 
        public string AddressType { get; set; }
        
    }
}
 