using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Contracts;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Domain.Entities;

namespace UberSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                if (user is not null)
                {
                    if (user.Role == Domain.Enums.UserRole.Customer)
                    {
                        var customer = new Customer
                        {
                            UserId = user.Id,
                            CreateAt = BitConverter.GetBytes(DateTime.Now.ToBinary())
                        };
                        _unitOfWork.CustomerRepository.Add(customer);
                    }
                    else if (user.Role == Domain.Enums.UserRole.Driver)
                    {
                        var driver = new Driver { 
                            UserId = user.Id, 
                            CreateAt = BitConverter.GetBytes(DateTime.Now.ToBinary()) 
                        };
                        _unitOfWork.DriverRepository.Add(driver);
                    }
                    _unitOfWork.UserRepository.Add(user);
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

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                _unitOfWork.UserRepository.Remove(user);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }

        public async Task<User?> GetUserById(Guid userId) => await _unitOfWork.UserRepository.FindAsync(userId);

        public async Task<User?> GetUserByToken(string token)
            => await _unitOfWork.UserRepository.Get().AsNoTracking()
            .FirstOrDefaultAsync(u => u.VerifiedToken == token);

        public async Task<User?> Login(string email, string password)
            => await _unitOfWork.UserRepository.Get().AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        public async Task<bool> UpdateUser(User user)
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
