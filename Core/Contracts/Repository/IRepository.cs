using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll(Expression<Func<T,bool>> filter=null);
        Task<T> Get(Expression<Func<T,bool>> filter);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
