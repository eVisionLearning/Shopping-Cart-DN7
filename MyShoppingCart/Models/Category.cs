using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShoppingCart.Models
{
    public class Category : BaseModel
    {
        [Required(ErrorMessage = "Category name is required.")]
		public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Logo")]
		[DataType(DataType.ImageUrl)]
		public string LogoUrl { get; set; }
        
        [NotMapped]
        public IFormFile Logo { get; set; }
        public bool Status { get; set; }
        public int Rank { get; set; }
        public List<Product> Products { get; set; }  // Navigational property
    }



}
