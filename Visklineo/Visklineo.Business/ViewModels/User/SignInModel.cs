using System.ComponentModel.DataAnnotations;

namespace Visklineo.Business.ViewModels.User
{
    public class SignInModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}