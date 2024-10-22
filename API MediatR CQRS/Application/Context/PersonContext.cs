using API_MediatR_CQRS.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace API_MediatR_CQRS.Application.Context
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
