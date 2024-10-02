using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Contracts;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Domain.Entities;

namespace UberSystem.Service
{
    public class DriverService(IUnitOfWork unitOfWork) : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> DeleteDriver(User driver)
        {
            try
            {
                if (driver is not null)
                {
                    _unitOfWork.UserRepository.Remove(driver);
                    await _unitOfWork.SaveAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }

        public async Task<User?> GetDriverById(Guid driverId)
            => await _unitOfWork.UserRepository.Get().AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == driverId);

        public async Task<IList<User>> GetDrivers()
            => await _unitOfWork.UserRepository.Get().AsNoTracking()
            .Include(u => u.Drivers)
            .Where(u => u.Role == Domain.Enums.UserRole.Driver)
            .ToListAsync();

        public async Task<bool> UpdateDriver(User driver)
        {
            try
            {
                if (driver is not null)
                {
                    _unitOfWork.UserRepository.Update(driver);
                    await _unitOfWork.SaveAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }
    }
}
