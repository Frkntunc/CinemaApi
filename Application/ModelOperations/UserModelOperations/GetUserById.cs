using Application.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelOperations.UserModelOperations
{
    public class GetUserById
    {
        public int Id { get; set; }
        private readonly IUserService _userService;
        public GetUserById(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDetailViewModel> Handle()
        {
            var user = await _userService.GetUserById(Id);
            if (user is null)
                throw new InvalidOperationException("Böyle bir kullanıcı yok.");

            UserDetailViewModel userViewModel = new UserDetailViewModel();
            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.Email = user.Email;

            return userViewModel;
        }
    }

    public class UserDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    
}
