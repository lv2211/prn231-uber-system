using UberSystem.Domain.Contracts.Repositories;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Repositories
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(UberSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
