using UberSystem.Domain.Contracts.Repositories;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(UberSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
