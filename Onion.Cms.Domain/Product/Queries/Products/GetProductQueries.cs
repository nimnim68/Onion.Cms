using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.DTOs.Site.Products;
using Onion.Cms.Domain.Product.Dtos.Product;

namespace Onion.Cms.Domain.Product.Queries.Products
{
    public class GetProductQueries : BaseQueries, IRequest<ResultProductSiteDto>
    {
        public long? CategoryId { get; set; }
    }
    public class GetProductByIdQueries : IRequest<ResultProductDetailsSiteDto>
    {
        public long Id { get; set; }
    }

    public class GetAdminProductByIdQueries : IRequest<ProductDto>
    {
        public long Id { get; set; }
    }

    public class GetProductFilterQueries : IRequest<ProductFilters>
    {
        
    }



}