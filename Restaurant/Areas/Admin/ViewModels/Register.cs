using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class Register
    {

        public int RegisterId { get; set; }

        [Required(ErrorMessage = "Please Enter UserName!")]

        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email!")]
        [DataType(DataType.EmailAddress)]
        public string? Emial { get; set; }

        [Required(ErrorMessage = "Please Enter Password!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not Match")]

        public string ConfirmPassword { get; set; }
    }
}
