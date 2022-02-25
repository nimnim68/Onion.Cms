using MediatR;
using Onion.Cms.Domain.Product.Dtos.Categories;
using System.Collections.Generic;

namespace Onion.Cms.Domain.Product.Queries.Categories
{
    public class GetCategoryQueries : IRequest<IReadOnlyList<GetCategoryDto>>
    {

    }
}