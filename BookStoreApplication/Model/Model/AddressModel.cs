using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
       /* [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]*/
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
        public int ContactNumber { get; set; }

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
        public int ZipCode { get; set; }

       
    }
}
