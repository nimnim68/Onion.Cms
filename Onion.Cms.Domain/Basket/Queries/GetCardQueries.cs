using System;
using MediatR;
using Onion.Cms.Domain.Basket.Dtos;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Basket.Queries
{
    public class GetCardQueries : IRequest<ResultDto<CartDto>>
    {
        public Guid? BrowserId { get; set; }
        public int? UserId { get; set; }
    }

    public class GetCardShippingQueries : IRequest<ResultDto<CartPayDto>>
    {
        public Guid? BrowserId { get; set; }
        public int? UserId { get; set; }
    }
}