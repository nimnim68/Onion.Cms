using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Product.Dtos.Categories;

namespace Onion.Cms.Domain.Product.Queries.Categories
{
    public class GetCategoryPaginationQueries : BaseQueries, IRequest<QueryList<GetCategoryDto>>
    {

    }
}