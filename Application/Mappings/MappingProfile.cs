using Application.ModelOperations.Authentications;
using Application.ModelOperations.UserModelOperations;
using AutoMapper;
using Domain.Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel,User>();
            CreateMap<User,UserDetailViewModel>();
            CreateMap<User,UserViewModel>();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
