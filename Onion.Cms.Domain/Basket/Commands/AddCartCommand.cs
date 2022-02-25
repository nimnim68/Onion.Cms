using System;
using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Basket.Commands
{
    public class AddCartCommand : IRequest<ResultDto>
    {
        public long ProductId { get; set; }
        public Guid BrowserId { get; set; }
        public int? UserId { get; set; }
        public bool IsFinished { get; set; }
        public string UserIp { get; set; }
        public string BrowserName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}