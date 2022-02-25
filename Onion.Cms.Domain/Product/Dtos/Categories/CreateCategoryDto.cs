using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Domain.Product.Dtos.Categories
{
    public class CreateCategoryDto : BaseModelDto<long>
    {
        [MaxLength(200, ErrorMessage = SharedResource.MaxLength)]
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [DisplayName(SharedResource.Parent)]
        public long? ParentId { get; set; }

        [DisplayName(SharedResource.Icon)]
        public string Icon { get; set; }

        public List<SelectListItem> Parents { get; set; }
        public List<SelectListItem> Icons { get; set; }

    }

    public class EditCategoryDto : CreateCategoryDto
    {
        public GetCategoryDto Parent { get; set; }

    }
}