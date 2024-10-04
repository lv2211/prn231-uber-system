using UberSystem.Domain.Entities;

namespace UberSystem.Domain.Contracts.Services
{
    public interface ICustomerService
    {
        Task<IList<User>> GetCustomers();
        
        Task<User?> GetCustomerById(Guid customerId);

        Task<Customer?> GetCustomerById(long customerId);

        Task<bool> AddTrip(Trip trip);

        Task<bool> CreateFeedbackForDriver(Rating rating);

        Task<bool> UpdateCustomer(User user);

        Task<bool> DeleteCustomer(User user);
    }
}
