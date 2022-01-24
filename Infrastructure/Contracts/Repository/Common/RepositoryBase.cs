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
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity> where TEntity : EntityBase where TContext : DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using (var _context=new TContext())
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
