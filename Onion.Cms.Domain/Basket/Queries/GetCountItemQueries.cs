using System;
using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Basket.Queries
{
    public class GetCountItemQueries : IRequest<ResultDto<int>>
    {
        public Guid? BrowserId { get; set; }
        public int? UserId { get; set; }
    }
}