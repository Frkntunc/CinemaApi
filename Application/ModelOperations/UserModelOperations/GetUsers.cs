using Application.Abstract;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetUsers(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle()
        {
            var userList = await _userService.GetAllUsers();
            List<UserViewModel> showedUsers = _mapper.Map<List<UserViewModel>>(userList);
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
