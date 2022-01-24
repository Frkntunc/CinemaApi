using Application.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelOperations.UserModelOperations
{
    public class GetUsers
    {
        private readonly IUserService _userService;
        public GetUsers(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserViewModel>> Handle()
        {
            var userList = await _userService.GetAllUsers();
            List<UserViewModel> showedUsers = new List<UserViewModel>();
            foreach (var item in userList)
            {
                showedUsers.Add(new UserViewModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email
                }) ;
            }
            return showedUsers;
        }
    }

    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
