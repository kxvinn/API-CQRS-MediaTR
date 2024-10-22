using MediatR;
using API_MediatR_CQRS.Application.Command;
using API_MediatR_CQRS.Application.Interfaces;
using API_MediatR_CQRS.Application.Models;

namespace API_MediatR_CQRS.Application.CommandHandler
{
    public class PersonCommandHandler : IRequestHandler<PersonCommand, Person>
    {
        private readonly IPersonRepository _repository;

        public PersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(PersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Age = request.Age,
                TaxId = request.TaxId
            };
            return await _repository.Add(person);
        }
    }
}
