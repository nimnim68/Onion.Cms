using Onion.Cms.Domain.Enum;
using Onion.Cms.Framework.Commands;

namespace Onion.Cms.Domain.Orders.Commands
{
    public class AddOrderDetailCommand :BaseCommandEntity
    {

        public long OrderId { get; set; }
        public long ProductId { get; set; }

        public decimal FinalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}