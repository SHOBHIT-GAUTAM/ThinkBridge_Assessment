using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge_WebAPI.Domain.Models
    
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product name should not be Empty"), MaxLength(255, ErrorMessage ="Length should be in less than 255 characters")]
        public string ProductName { get; set; }

         [Required(ErrorMessage = "Product Quantity should not be Empty"), Range(1, 100, ErrorMessage = "Quantity should be in less than 100 Units")]
         public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Category should not be Empty"), RegularExpression("[1-9][0-9]*", ErrorMessage = "Price should be greater than 0")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Product Description should not be Empty"), MaxLength(255, ErrorMessage = "Length should be in less than 255 characters")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Price should not be Empty"), RegularExpression("[1-9][0-9]*", ErrorMessage ="Price should be greater than 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Date should not be Empty")]
        public DateTime AddedOn { get; set; }
        

    }
}
