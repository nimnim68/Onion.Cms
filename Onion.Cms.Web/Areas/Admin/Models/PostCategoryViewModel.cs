using Microsoft.AspNetCore.Http;
using Onion.Cms.Resources.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Onion.Cms.Web.Areas.Admin.Models
{
    public class PostCategoryViewModel
    {
        [DisplayName(SharedResource.Title)]
        [Required(ErrorMessage = SharedResource.Required)]
        public string Title { get; set; }

        public int Id { get; set; }
    }
}
