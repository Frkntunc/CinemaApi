using Application.Contracts.Repository;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts.Repository.Common
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {

        protected readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task Add(TEntity entity)
        {

            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task Delete(TEntity entity)
        {

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {

            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(filter);

        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return await _dbContext.Set<TEntity>().ToListAsync();

        }

        public async Task Update(TEntity entity)
        {

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }
    }
}
