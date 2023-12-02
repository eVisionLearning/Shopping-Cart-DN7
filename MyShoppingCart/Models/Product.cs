using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShoppingCart.Models
{
    public class Product : BaseModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }  // Navigational property

		[Required(ErrorMessage = "A Purchase price is required.")]
		[DataType(DataType.Currency)]
		[Range(1, double.MaxValue, ErrorMessage = "Purchase Price cannot be 0")]
		public int PurchasePrice { get; set; }

		[Required(ErrorMessage = "A Sales price is required.")]
		[DataType(DataType.Currency)]
		[Range(1, double.MaxValue, ErrorMessage = "Sales Price cannot be 0")]
		public int SalesPrice { get; set; }

		[Required(ErrorMessage = "A Discount price is required.")]
		[DataType(DataType.Currency)]
		[Range(1, double.MaxValue, ErrorMessage = "Discount Price cannot be 0")]
		public int DiscountedPrice { get; set; }

		[Required(ErrorMessage = "Stocking amount required")]
		[DataType(DataType.Currency)]
		[Range(-1, int.MaxValue, ErrorMessage = "Stock cannot be -1")]
		public int Stock { get; set; }

        public string Description { get; set; }
        public List<ProductImage> Images { get; set; }  // Navigational property

		[NotMapped]
        public List<IFormFile> ImagesUploads { get; set; }
    }



}
