using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Model
{
    /// <summary>
    /// BookStore model class
    /// </summary>
    public class BookStoreModel
    {
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookID { get; set; }

        /// <summary>
        /// Gets or sets the book tittle.
        /// </summary>
        /// <value>
        /// The book tittle.
        /// </value>
        [Required(ErrorMessage = "BookTitle cannot be empty")]
        public string BookTittle { get; set; }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        /// <value>
        /// The name of the author.
        /// </value>
        [Required(ErrorMessage = "AuthorName cannot be empty")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Required(ErrorMessage = "Price cannot be empty")]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        [Required(ErrorMessage = "Summary cannot be empty")] 
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the book image.
        /// </summary>
        /// <value>
        /// The book image.
        /// </value>
        [Required(ErrorMessage = "BookImage cannot be empty")] 
        public string BookImage { get; set; }

        /// <summary>
        /// Gets or sets the book count.
        /// </summary>
        /// <value>
        /// The book count.
        /// </value>
        [Required(ErrorMessage = "BookCount cannot be empty")]
        public int BookCount { get; set; }
    }
}