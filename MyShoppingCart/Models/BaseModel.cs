using System.ComponentModel.DataAnnotations;

namespace MyShoppingCart.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


        [DataType(DataType.DateTime)]
        [Display(Name = "Last Updated On")]
        public DateTime? LastUpdatedOn { get; set; }
    }



}
