using MediatR;
using API_MediatR_CQRS.Application.Interfaces;
using API_MediatR_CQRS.Application.Models;
using API_MediatR_CQRS.Application.Queries;

namespace API_MediatR_CQRS.Application.CommandHandler
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IPersonRepository _repository;

        public GetPersonByIdQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
