using System.Collections.Generic;
using MediatR;
using Onion.Cms.Domain.Arrangements.Dtos;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Arrangements.Queries
{
    public class ArrangementsQueries : IRequest<IReadOnlyList<ArrangementGetDto>>
    {
        public long? StoreId { get; set; }
    }
    public class ArrangementsPaginationQueries : BaseQueries, IRequest<QueryList<ArrangementGetDto>>
    {
        
    }

    public class ArrangementByIdQueries : IRequest<ResultDto<ArrangementGetDto>>
    {
        public long Id { get; set; }
    }
}