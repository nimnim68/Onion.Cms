using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Product.Commands.Brands
{
    public class BrandCreateCommand : IRequest<ResultDto>
    {
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Remarks { get; set; }
        public string Description { get; set; }
        public string Src { get; set; }
    }
    
    public  class BrandUpdateCommand : BrandCreateCommand
    {
        public int Id { get; set; }

    }
}