using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;

namespace TimeTracker.Service.Contract
{
    public interface IGenericService<T> where T : class
    {
        Task<Response<T>> GetById(Guid Id);
        Task<Response<IEnumerable<T>>> GetAll();
        Task<Response<IEnumerable<T>>> Find(Expression<Func<T, bool>> expression);
        Task<Response<bool>> Add(T entity);
        Task<Response<bool>> AddRange(IEnumerable<T> entities);
        Task<Response<bool>> Remove(T entity);
        Task<Response<bool>> RemoveRange(IEnumerable<T> entities);
        Task<Response<bool>> Update(T entity);
    }
}
