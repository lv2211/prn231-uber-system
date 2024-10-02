namespace UberSystem.Domain.Contracts
{
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Get all entities using IQueryable interface
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Get();

        /// <summary>
        /// Get an entity by its key values with asynchronous operation
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<T?> FindAsync(params object[] keyValues);

        /// <summary>
        /// Get an entity by its key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T? Find(params object[] keyValues);

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Add a list of entities
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Update a list of entities
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Remove an entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Remove a list of entities
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<T> entities);
    }
}
