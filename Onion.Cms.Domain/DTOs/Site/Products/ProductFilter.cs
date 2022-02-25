using System.Collections.Generic;
using System.ComponentModel;
using Onion.Cms.Domain.Product.Dtos.Brands;
using Onion.Cms.Domain.Product.Dtos.Categories;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Domain.DTOs.Site.Products
{
    public class ProductFilters
    {
        public IReadOnlyList<GetBrandDto> Brands { get; set; }
        public IReadOnlyList<GetCategoryDto> Categories { get; set; }

        [DisplayName(SharedResource.Available)]
        public bool Available { get; set; }

        public decimal MaxAmount { get; set; }
    }
}