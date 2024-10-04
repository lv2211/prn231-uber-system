using UberSystem.Domain.Entities;

namespace UberSystem.Domain.Contracts.Services
{
    public interface ITripService
    {
        Task<Trip?> GetTrip(long tripId);

        Task<bool> UpdateTrip(Trip trip);
    }
}
