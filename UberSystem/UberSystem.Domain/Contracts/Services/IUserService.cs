using UberSystem.Domain.Entities;

namespace UberSystem.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<User?> Login(string email, string password);

        Task<User?> GetUserByToken(string token);

        Task<User?> GetUserById(Guid userId);

        Task<bool> UpdateUser(User user);

        Task<bool> AddUser(User user);

        Task<bool> DeleteUser(User user);
    }
}
