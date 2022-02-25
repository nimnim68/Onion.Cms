using System.ComponentModel;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Domain.Product.Dtos.Brands
{
    public class GetBrandDto
    {
        public int Id { get; set; }
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [DisplayName(SharedResource.EnglishTitle)]
        public string EnglishTitle { get; set; }

        [DisplayName(SharedResource.ShortDescription)]
        public string Description { get; set; }

        [DisplayName(SharedResource.Photo)]
        public string Src { get; set; }

        public int Count { get; set; }
    }
}