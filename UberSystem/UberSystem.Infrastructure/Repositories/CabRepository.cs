using UberSystem.Domain.Contracts.Repositories;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Repositories
{
    public class CabRepository : Repository<Cab>, ICabRepository
    {
        public CabRepository(UberSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
