using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_MediatR_CQRS.Application.Models;

namespace API_MediatR_CQRS.Application.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetById(Guid id);
        Task<Person> Add(Person person);
        Task<Person> Update(Guid id, Person person);
        Task<bool> DeleteById(Guid id);
        Task SaveChanges();
    }
}
