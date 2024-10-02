using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Contracts;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Enums;

namespace UberSystem.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteCustomer(User user)
        {
            try
            {
                if (user is not null) 
                {
                    _unitOfWork.UserRepository.Remove(user);
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

        public async Task<User?> GetCustomerById(Guid customerId)
            => await _unitOfWork.UserRepository.Get().AsNoTracking()
            .Include(u => u.Customers)
            .FirstOrDefaultAsync(u => u.Id == customerId);

        public async Task<IList<User>> GetCustomers()
            => await _unitOfWork.UserRepository.Get().AsNoTracking()
            .Include(u => u.Customers)
            .Where(u => u.Role == UserRole.Customer).ToListAsync();

        public async Task<bool> UpdateCustomer(User user)
        {
            try
            {
                if (user is not null)
                {
                    _unitOfWork.UserRepository.Update(user);
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
