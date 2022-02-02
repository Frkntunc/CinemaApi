using Domain.Entities.Authentications;
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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        protected readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<string>> GetUserRoles(User user)
        {

            var result = from r in _dbContext.Roles
                         join ur in _dbContext.UserRoles
                         on r.ID equals ur.RoleId
                         where user.ID == ur.UserId
                         select new Role { Name = r.Name }.ToString();
            return result.ToList();

        }
    }
}
