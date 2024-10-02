using UberSystem.Domain.Entities;

namespace UberSystem.Domain.Contracts.Services
{
    public interface IDriverService
    {
        Task<IList<User>> GetDrivers();

        Task<User?> GetDriverById(Guid driverId);

        Task<bool> UpdateDriver(User driver);

        Task<bool> DeleteDriver(User driver);
    }
}
