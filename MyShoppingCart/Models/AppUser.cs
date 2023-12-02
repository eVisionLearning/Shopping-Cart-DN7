using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyShoppingCart.Models
{
    public class AppUser : BaseModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100,MinimumLength =3,ErrorMessage = "Please enter 3-100 characters for name")]
        public string Username { get; set; }

		public string HashPassword { get; set; }

		[Required(ErrorMessage = "An Email is required.")]
		[DataType(DataType.EmailAddress)]
		[StringLength(100, ErrorMessage = "Email address length is not valid")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Street Address is required.")]
		[StringLength(100, ErrorMessage = "Street address length is not valid")]
		public string StreetAddress { get; set; }

		[Required(ErrorMessage = "City is required.")]
		[StringLength(86, ErrorMessage = "City length is not valid")]
		public string City { get; set; }

		[Required(ErrorMessage = "A country is required.")]
		[StringLength(100, ErrorMessage = "Country field length is not valid")]
		public string Country { get; set; }

		//[DataType(DataType.ImageUrl)]
		public string ProfilePhotoUrl { get; set; }  // Profile photo

        public List<Order> Orders { get; set; }  // Navigational property
    }


	public class AppUserViewModel : BaseModel
	{
		[Required(ErrorMessage = "Username is required.")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Please enter 3-100 characters for name")]
        [Remote("CheckUniqueUserName", "RV", ErrorMessage = "UserName already exists")]
        public string Username { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.Password)]
		[StringLength(200, MinimumLength = 6, ErrorMessage = "Password must be atleast 6 character")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirmed Password is required.")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password does not match")]
		public string ConfirmedPassword { get; set; }

		[Required(ErrorMessage = "An Email is required.")]
		[DataType(DataType.EmailAddress)]
		[StringLength(100, ErrorMessage = "Email address length is not valid")]
		[Remote("CheckUniqueEmail", "RV", ErrorMessage = "Email already exists")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Street Address is required.")]
		[StringLength(100, ErrorMessage = "Street address length is not valid")]
		public string StreetAddress { get; set; }

		[Required(ErrorMessage = "City is required.")]
		[StringLength(86, ErrorMessage = "City length is not valid")]
		public string City { get; set; }

		[Required(ErrorMessage = "A country is required.")]
		[StringLength(100, ErrorMessage = "Country field length is not valid")]
		public string Country { get; set; }

		//[DataType(DataType.ImageUrl)]
		public string ProfilePhotoUrl { get; set; }  // Profile photo

		public IFormFile ProfilePhoto { get; set; }	
	}


}


