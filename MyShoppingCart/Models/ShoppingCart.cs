namespace MyShoppingCart.Models
{
    public class ShoppingCart : BaseModel
    {
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }  // Navigational property

        public List<CartItem> CartItems { get; set; }  // Navigational property
    }



}
