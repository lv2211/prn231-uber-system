namespace UberSystem.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Save any changes into database with asynchronous operation
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Revert any changes made in the current transaction
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
