using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Payments.Entities;
using Onion.Cms.Domain.Payments.Repositories;

namespace Onion.Cms.DAL.Payments.Repositories
{
    public class PaymentRepository : EfRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}