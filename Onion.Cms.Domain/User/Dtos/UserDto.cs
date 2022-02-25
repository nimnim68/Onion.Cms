using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Domain.User.Dtos
{
    public class UserDto : BaseModelDto<long>
    {
        [DisplayName(SharedResource.Email)]
        [Required(ErrorMessage = SharedResource.Email)]
        public string Email { get; set; }

        public string RegisterDate { get; set; }

        public List<string> Roles { get; set; }

    }
}
