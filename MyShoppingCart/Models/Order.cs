using System.ComponentModel.DataAnnotations;

namespace MyShoppingCart.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }  // Navigational property

		[Required(ErrorMessage = "A Shipping Address is required.")]
		[StringLength(100, ErrorMessage = "Shipping Address is too long")]
		public string ShippingAddress { get; set; }

		[Required(ErrorMessage = "A Shipping City is required.")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Shipping city name is long")]
		public string ShippingCity { get; set; }
		
		[Required(ErrorMessage = "A shiiping phone number is required.")]
		[DataType(DataType.PhoneNumber)]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Incorrect phone number length ")]
		public string ShippingContactNumber { get; set; }
		
		[Required(ErrorMessage = "Username is required.")]
		[DataType(DataType.EmailAddress)]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Please enter 3-100 characters for name")]
		public string ShippingContactEmail { get; set; }

        public List<OrderItem> OrderItems { get; set; }  // Navigational property
    }



}
