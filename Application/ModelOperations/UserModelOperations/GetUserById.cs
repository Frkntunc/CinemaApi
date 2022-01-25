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
    public class GetUserById
    {
        public int Id { get; set; }
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserById(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDetailViewModel> Handle()
        {
            var user = await _userService.GetUserById(Id);
            if (user is null)
                throw new InvalidOperationException("Böyle bir kullanıcı yok.");

            var userViewModel = _mapper.Map<UserDetailViewModel>(user);
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
