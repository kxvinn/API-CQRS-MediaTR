using MediatR;
using API_MediatR_CQRS.Application.Interfaces;
using API_MediatR_CQRS.Application.Models;
using API_MediatR_CQRS.Application.Queries;

namespace API_MediatR_CQRS.Application.CommandHandler
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, IEnumerable<Person>>
    {
        private readonly IPersonRepository _repository;

        public GetPersonsQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
