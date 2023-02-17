using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuickKartMVC.Models
{
    public class Products
    {
        [Key]
        [Required(ErrorMessage = "Product Id is mandatory")]
        [DisplayName("Product ID")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is mandatory")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Category Id is mandatory")]
        [DisplayName("Category ID")]
        public byte? CategoryId { get; set; }
        [Required(ErrorMessage = "Price is mandatory")]
        [Range(minimum: 1, maximum: 10000000000000)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Quantity Available is mandatory")]
        [DisplayName("Quantity Available")]
        public int QuantityAvailable { get; set; }
    }
}
