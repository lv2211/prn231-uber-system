using UberSystem.Domain.Entities;

namespace UberSystem.Domain.Contracts.Services
{
    public interface IDriverService
    {
        Task<IList<User>> GetDrivers();

        Task<User?> GetDriverById(Guid driverId);

        Task<Driver?> GetDriverById(long driverId);

        Task<bool> UpdateDriver(User driver);

        /// <summary>
        /// Update driver's status
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        Task<bool> UpdateDriverStatus(Driver driver);

        Task<bool> DeleteDriver(User driver);
    }
}
