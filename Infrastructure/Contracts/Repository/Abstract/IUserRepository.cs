﻿using Application.Contracts.Repository;
using Domain.Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<string>> GetUserRoles(User user);
    }
}
