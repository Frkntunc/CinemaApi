using Application.Abstract;
using Application.ValidationRules.UserValidationRules;
using Domain.Entities.Authentications;
using FluentValidation;
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

        public async Task<bool> CheckPassword(string email, string password)
        {
            var user = await _userRepository.Get(u => u.Email == email);
            if (user.Password == password)
                return true;

            return false;
        }

        public async Task<List<string>> GetRoles(User user)
        {
            return await _userRepository.GetUserRoles(user);
        }
    }
}
