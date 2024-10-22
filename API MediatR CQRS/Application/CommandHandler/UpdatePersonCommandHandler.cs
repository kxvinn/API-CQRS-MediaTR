using MediatR;
using API_MediatR_CQRS.Application.Command;
using API_MediatR_CQRS.Application.Interfaces;
using API_MediatR_CQRS.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace API_MediatR_CQRS.Application.CommandHandler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;

        public UpdatePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var personToUpdate = new Person
            {
                Id = request.Id,
                Name = request.Name,
                Age = request.Age,
                TaxId = request.TaxId
            };

            var result = await _repository.Update(personToUpdate);
            return result != null;
        }
    }
}
