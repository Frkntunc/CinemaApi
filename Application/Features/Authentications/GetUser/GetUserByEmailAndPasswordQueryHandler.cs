using Application.Abstract;
using Application.ModelOperations.Authentications;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Authentications.GetUser
{
    public class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<GetUserByEmailAndPasswordQuery, UserModel>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByEmailAndPasswordQueryHandler(IUserService userService,
           IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<UserModel> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmail(request.Email);

            if (user == null)
                return null;

            var userModel = new UserModel();

            var userSigingResult = await _userService.CheckPassword(request.Email, request.Password);

            if (userSigingResult)
            {
                userModel = _mapper.Map<UserModel>(user);
                userModel.Roles = await _userService.GetRoles(user);
            }

            return userModel;
        }
    }
}
