using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Domain.User.Dtos
{
    public class LoginUserDto
    {
        [DisplayName(SharedResource.Email)]
        [EmailAddress(ErrorMessage = SharedResource.EmailError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName(SharedResource.Password)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class ResetPasswordDto
    {
        [DataType(DataType.Password)]
        [DisplayName(SharedResource.Password)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName(SharedResource.RePassword)]
        [Compare(nameof(Password), ErrorMessage = SharedResource.RePasswordError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string RePassword { get; set; }

        public string UserId { get; set; }
        public string TokenId { get; set; }
    }
    public class ChangePasswordDto
    {
        [DataType(DataType.Password)]
        [DisplayName(SharedResource.CurrentPassword)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName(SharedResource.Password)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName(SharedResource.RePassword)]
        [Compare(nameof(NewPassword), ErrorMessage = SharedResource.RePasswordError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string RePassword { get; set; }
    }

}
