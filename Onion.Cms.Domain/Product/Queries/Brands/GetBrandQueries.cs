using System.Collections.Generic;
using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Product.Dtos.Brands;

namespace Onion.Cms.Domain.Product.Queries.Brands
{
    public class GetBrandQueries : BaseQueries, IRequest<IReadOnlyList<GetBrandDto>>
    {

    }
}