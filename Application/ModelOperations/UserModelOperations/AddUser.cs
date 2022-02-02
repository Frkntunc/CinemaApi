using Application.Abstract;
using AutoMapper;
using Domain.Entities.Authentications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ModelOperations.UserModelOperations
{
    public class AddUser:IRequestHandler<CreateUserModel,int>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AddUser(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserModel request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmail(request.Email);

            if (user != null)
                throw new InvalidOperationException("Böyle bir kullanıcı var");

            user = _mapper.Map<User>(request);
            await _userService.AddUser(user);
            return user.ID;
        }
    }

    public class CreateUserModel : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
