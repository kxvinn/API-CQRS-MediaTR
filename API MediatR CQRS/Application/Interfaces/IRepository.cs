using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_MediatR_CQRS.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}
