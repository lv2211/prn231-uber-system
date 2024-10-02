using UberSystem.Domain.Contracts.Repositories;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(UberSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
