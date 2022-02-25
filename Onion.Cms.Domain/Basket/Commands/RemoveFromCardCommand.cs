using System;
using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Basket.Commands
{
    public class RemoveFromCardCommand : IRequest<ResultDto>
    {
        public long CartItemId { get; set; }
        public long ProductId { get; set; }
        public Guid? BrowserId { get; set; }
        public int? UserId { get; set; }
    }
}