using System.Collections.Generic;
using Onion.Cms.Domain.Product.Dtos.Product;

namespace Onion.Cms.Web.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public string Editor1 { get; set; }
        public ProductDto ProductDto { get; set; }
        public List<ProductFeatureDto> ProductFeatureDto { get; set; }
        public List<ProductTechnicalDto> ProductTechnical { get; set; }
    }

}