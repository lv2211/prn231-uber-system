using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Contracts;
using UberSystem.Domain.Contracts.Repositories;

namespace UberSystem.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UberSystemDbContext _dbContext;

        public UnitOfWork(
            UberSystemDbContext dbContext,
            ICabRepository cabRepository,
            ICustomerRepository customerRepository,
            IDriverRepository driverRepository,
            IPaymentRepository paymentRepository,
            IRatingRepository ratingRepository,
            ITripRepository tripRepository,
            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            CabRepository = cabRepository;
            CustomerRepository = customerRepository;
            DriverRepository = driverRepository;
            PaymentRepository = paymentRepository;
            RatingRepository = ratingRepository;
            TripRepository = tripRepository;
            UserRepository = userRepository;
        }

        public ICabRepository CabRepository { get; }

        public ICustomerRepository CustomerRepository { get; }

        public IDriverRepository DriverRepository { get; }

        public IPaymentRepository PaymentRepository { get; }

        public IRatingRepository RatingRepository { get; }

        public ITripRepository TripRepository { get; }

        public IUserRepository UserRepository { get; }

        public void Dispose() => _dbContext.Dispose();

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        // Remove the entity from DbContext
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        // Reload the entity's data from the database
                        entry.Reload();
                        break;
                }
            }
            // Save any remaining changes to the database
            await SaveAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default) 
            => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
