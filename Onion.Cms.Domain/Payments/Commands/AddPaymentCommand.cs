using System;
using MediatR;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Domain;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Payments.Commands
{
    public class AddPaymentCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public decimal Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
        public PaymentType PaymentType { get; set; }
        public long OrderId { get; set; }
        public string StatusCode { get; set; }
        public string StatusCodeMessage { get; set; }
    }
}