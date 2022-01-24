using Domain.Entities;
using Infrastructure.Contracts.Repository.Abstract;
using Infrastructure.Contracts.Repository.Common;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts.Repository.Concrete
{
    public class UserRepository : RepositoryBase<User,AppDbContext>, IUserRepository
    {
    }
}
