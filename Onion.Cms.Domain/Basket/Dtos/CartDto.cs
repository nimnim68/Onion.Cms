using System.Collections.Generic;
using Onion.Cms.Domain.Enum;

namespace Onion.Cms.Domain.Basket.Dtos
{
    public class CartDto
    {
        public long CartId { get; set; }
        public List<CartItemDto> CartItemDtos { get; set; }
    }
    public class CartPayDto
    {
        public long CartId { get; set; }
        public decimal FinalAmount { get; set; }
        public int Count { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}