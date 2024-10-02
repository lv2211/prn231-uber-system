using UberSystem.Domain.Contracts.Repositories;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UberSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
