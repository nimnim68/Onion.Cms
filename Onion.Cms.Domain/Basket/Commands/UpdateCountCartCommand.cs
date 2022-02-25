using System;
using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Basket.Commands
{
    public class UpdateCountCartCommand : IRequest<ResultDto>
    {
        public int Count { get; set; }
        public long CartItemId { get; set; }
        public Guid? BrowserId { get; set; }
        public int? UserId { get; set; }
    }
    public class UpdateCartFinished : IRequest<ResultDto>
    {
        public long CartId { get; set; }
    }
}