using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
