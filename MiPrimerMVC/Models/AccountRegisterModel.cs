using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerMVC.Models
{
    public class AccountRegisterModel
    {
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please use a valid e-mail address.")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "First name should be between 2 and 50 characters.", MinimumLength = 2)]
        [DisplayName("Name")]
        [RegularExpression("[a-zA-Z ]*", ErrorMessage = "Your name should only contain letters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [StringLength(32, ErrorMessage = "Password should be between 8 and 32 characters.", MinimumLength = 8)]
        [Compare("ConfirmPassword", ErrorMessage = "Password and Confirm Password should be the same!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [StringLength(32, ErrorMessage = "Confirm Password should be between 8 and 32 characters.", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password should be the same!")]
        public string ConfirmPassword { get; set; }
    }
}