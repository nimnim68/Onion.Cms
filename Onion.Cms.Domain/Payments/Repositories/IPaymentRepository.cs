using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Payments.Entities;

namespace Onion.Cms.Domain.Payments.Repositories
{
    public interface IPaymentRepository : IAsyncRepository<Payment>
    {
        
    }
}