using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Model
{
    public class CartModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CartID { get; set; }

        public int Book_ID { get; set; }

        public int SelectBookCount { get; set; }

        [ForeignKey("Book_ID")]
        public BookStoreModel book { get;set }


    }
}
