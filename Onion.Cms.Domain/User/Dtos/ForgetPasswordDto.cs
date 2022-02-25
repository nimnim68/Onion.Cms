using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Domain.User.Dtos
{
    public class ForgetPasswordDto
    {
        [DisplayName(SharedResource.Email)]
        [EmailAddress(ErrorMessage = SharedResource.EmailError)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Email { get; set; }
    }
}