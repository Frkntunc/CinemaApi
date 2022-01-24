using Application.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelOperations.UserModelOperations
{
    public class AddUser
    {
        public CreateUserModel createUserModel { get; set; }
        private readonly IUserService _userService;

        public AddUser(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle()
        {
            var user = await _userService.GetUserByEmail(createUserModel.Email);

            if (user != null)
                throw new InvalidOperationException("Böyle bir kullanıcı var");

            user = new User();
            user.FirstName = createUserModel.FirstName;
            user.LastName = createUserModel.LastName;
            user.Email = createUserModel.Email;
            user.Password = createUserModel.Password;

            await _userService.AddUser(user);
        }

    }

    public class CreateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
