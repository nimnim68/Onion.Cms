using System.Collections.Generic;
using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Stores.Dtos;

namespace Onion.Cms.Domain.Stores.Queries
{
    public class StoreQuery : IRequest<IReadOnlyList<StoreDto>>
    {
        
    }
}