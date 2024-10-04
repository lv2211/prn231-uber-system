using UberSystem.Domain.Contracts;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Domain.Entities;

namespace UberSystem.Service
{
    public class TripService(IUnitOfWork unitOfWork) : ITripService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Trip?> GetTrip(long tripId) => await _unitOfWork.TripRepository.FindAsync(tripId);

        public async Task<bool> UpdateTrip(Trip trip)
        {
            try
            {
                if (trip is not null)
                {
                    _unitOfWork.TripRepository.Update(trip);
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
