using System.ComponentModel.DataAnnotations;

namespace RookieShop.BackEnd.ViewModel.CustomAuthentication
{
    public class RegisterAuthModelVM
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public string ReturnUrl { get; set; }
    }
}