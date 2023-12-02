using System.ComponentModel.DataAnnotations;

namespace MyShoppingCart.Models
{
    public class ProductImage : BaseModel
    {
		[Required(ErrorMessage = "A Discount price is required.")]
		[DataType(DataType.ImageUrl)]
		public string ImageUrl { get; set; }  // Assuming using byte array for image data
		
		public int Rank { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }  // Navigational property
    }



}
