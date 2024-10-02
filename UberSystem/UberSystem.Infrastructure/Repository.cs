using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Contracts;

namespace UberSystem.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly UberSystemDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(UberSystemDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity) => _dbContext.Add(entity);

        public void AddRange(IEnumerable<T> entities) => _dbContext.AddRange(entities);

        public T? Find(params object[] keyValues) => _dbSet.Find(keyValues);

        public async Task<T?> FindAsync(params object[] keyValues) => await _dbSet.FindAsync(keyValues);

        public IQueryable<T> Get() => _dbSet.AsQueryable();

        public void Remove(T entity) => _dbContext.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _dbContext.RemoveRange(entities);

        public void Update(T entity) => _dbContext.Update(entity);

        public void UpdateRange(IEnumerable<T> entities) => _dbContext.UpdateRange(entities);
    }
}
