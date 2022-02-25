using MediatR;
using Onion.Cms.Domain.Product.Dtos.Brands;

namespace Onion.Cms.Domain.Product.Queries.Brands
{
    public class GetBrandByIdQueries : IRequest<GetBrandDto>
    {
        public int Id { get; set; }
    }
}