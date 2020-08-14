﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreCommonLayer.Model
{
   public class RegistrationModel
    { 
        [Key]
        [Required(ErrorMessage = "Email Must Be Required")]
        [Display(Name = "EmailAddress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConformPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Gender { get; set; }
    }
}

