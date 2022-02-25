using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Stores.Dtos;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Stores.Queries
{
    public class StoreGetByCodeQuery : IRequest<ResultDto<StoreDto>>
    {
        public string Code { get; set; }
    }
}