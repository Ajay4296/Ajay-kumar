using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using SQLite;

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
        [Key]
        public int UserLoginID { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        



    }
}
