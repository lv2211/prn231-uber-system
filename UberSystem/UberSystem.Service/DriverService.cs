using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Contracts;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Domain.Entities;
using UberSystem.Dto.Helpers;

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

        public async Task<IList<Driver>> GetAvailableDrivers(double sourceLatitude, double sourceLongitude)
        {
            var availableDrivers = await _unitOfWork.DriverRepository.Get()
                .AsNoTracking()
                .Include(d => d.User)
                .Include(d => d.Cabs)
                .Where(d => d.Status == Domain.Enums.DriverStatus.Available)
                .ToListAsync();
            
            var nearbyDrivers = availableDrivers.Where(d => d.LocationLatitude.HasValue && d.LocationLongitude.HasValue)
                .Select(d => new
                {
                    Driver = d,
                    d.User,
                    d.Cabs,
                    Distance = HaversineFormula.CalculateDistance(sourceLatitude, sourceLongitude, 
                        d.LocationLatitude.Value, d.LocationLongitude.Value)
                })
                .Where(x => x.Distance <= 2)    // Filter drivers within 2 km radius
                .OrderByDescending(x => x.Driver.Ratings.Average(r => r.TripRating))
                .Select(x => x.Driver)
                .ToList();
            return nearbyDrivers;
        }

        public async Task<User?> GetDriverById(Guid driverId)
            => await _unitOfWork.UserRepository.Get().AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == driverId);

        public async Task<Driver?> GetDriverById(long driverId)
            => await _unitOfWork.DriverRepository.FindAsync(driverId);

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

        public async Task<bool> UpdateDriverStatus(Driver driver)
        {
            try
            {
                if (driver is not null)
                {
                    _unitOfWork.DriverRepository.Update(driver);
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
