using System.ComponentModel.DataAnnotations;

namespace MyShoppingCart.Models
{

    public class OrderItem : BaseModel
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }  // Navigational property

		[Range(1, double.MaxValue, ErrorMessage = "Quantity must be atleast 1")]
		public int Quantity { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }  // Navigational property
    }
}
