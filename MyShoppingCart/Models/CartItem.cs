using System.ComponentModel.DataAnnotations;

namespace MyShoppingCart.Models
{
    public class CartItem : BaseModel
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }  // Navigational property

        [Range(1,double.MaxValue, ErrorMessage = "Quantity must be atleast 1")]
        public int Quantity { get; set; }
		
		public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }  // Navigational property
    }
}
