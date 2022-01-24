using Application.Abstract;
using Domain.Entities;
using Infrastructure.Contracts.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(User user)
        {
           await _userRepository.Add(user);
        }

        public async Task DeleteUser(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int Id)
        {
            return await _userRepository.Get(u=>u.ID==Id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.Get(u => u.Email == email);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }
    }
}
