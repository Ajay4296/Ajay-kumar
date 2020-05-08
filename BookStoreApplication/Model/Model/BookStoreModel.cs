using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Model
{
    public class BookStoreModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int BookID { get; set; }

       
        public string BookTittle { get; set; }

       
        public string AuthorName { get; set; }

       
        public double Price { get; set; }

       
        public string Summary { get; set; }

      
        public string BookImage { get; set; }

        
        public int BookCount { get; set; }

    }
}