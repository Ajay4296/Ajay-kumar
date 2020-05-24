using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    /// <summary>
    /// UserLogin class
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserLoginID { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }





    }
}
