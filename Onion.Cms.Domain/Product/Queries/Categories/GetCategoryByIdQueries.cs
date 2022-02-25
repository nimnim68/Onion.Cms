using MediatR;
using Onion.Cms.Domain.Product.Dtos.Categories;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Product.Queries.Categories
{
    public class GetCategoryByIdQueries :  IRequest<ResultDto<GetCategoryDto>>
    {
        public long Id { get; set; }
    }
}