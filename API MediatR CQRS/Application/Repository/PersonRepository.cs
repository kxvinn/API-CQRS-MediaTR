using API_MediatR_CQRS.Application.Models;
using API_MediatR_CQRS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_MediatR_CQRS.Application.Context;

namespace API_MediatR_CQRS.Application.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetById(Guid id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Person> Add(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> Update(Person person)
        {
            var existingPerson = await _context.Persons.FindAsync(person.Id);
            if (existingPerson == null)
            {
                return null;
            }

            existingPerson.Name = person.Name;
            existingPerson.Age = person.Age;
            existingPerson.TaxId = person.TaxId;

            await _context.SaveChangesAsync();
            return existingPerson;
        }

        public async Task<bool> Delete(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return false;
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
