using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    /// <summary>
    /// cart model class
    /// </summary>
    public class CartModel
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Key]
        public int CartID { get; set; }

        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
       
       

        public int BookID { get; set; }

        /// <summary>
        /// Gets or sets the select book count.
        /// </summary>
        /// <value>
        /// The select book count.
        /// </value>
        [Required(ErrorMessage = "SelectBookCount should not be empty")]
        public int SelectBookCount { get; set; }
    }
}
