using MediatR;
using API_MediatR_CQRS.Application.Command;
using API_MediatR_CQRS.Application.Interfaces;

namespace API_MediatR_CQRS.Application.CommandHandler
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;

        public DeletePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Delete(request.Id);
        }
    }
}