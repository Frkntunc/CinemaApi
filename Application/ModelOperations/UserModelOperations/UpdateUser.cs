using Application.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelOperations.UserModelOperations
{
    public class UpdateUser
    {
        public UpdateUserViewModel user { get; set; }
        public int Id { get; set; }

        private readonly IUserService _userService;
        public UpdateUser(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle()
        {
            var updatedUser = await _userService.GetUserById(Id);
            if (updatedUser is null)
                throw new InvalidOperationException("Böyle bir kullanıcı yok");

            updatedUser.FirstName = user.FirstName != default ? user.FirstName : updatedUser.FirstName;
            updatedUser.LastName = user.LastName != default ? user.LastName : updatedUser.LastName;
            updatedUser.Password = user.Password != default ? user.Password : updatedUser.Password;

            await _userService.UpdateUser(updatedUser);
        }
    }

    public class UpdateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
