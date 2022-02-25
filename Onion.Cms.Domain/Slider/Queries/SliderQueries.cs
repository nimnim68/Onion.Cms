using System.Collections.Generic;
using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Slider.Dtos;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Slider.Queries
{
    public class SliderQueries : IRequest<IReadOnlyList<SliderDto>>
    {

    }
    public class SliderPaginationQueries : BaseQueries, IRequest<QueryList<SliderDto>>
    {

    }

    public class SliderByIdQueries : IRequest<ResultDto<SliderDto>>
    {
        public int Id { get; set; }
    }
}