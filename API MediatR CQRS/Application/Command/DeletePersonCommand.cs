using MediatR;

namespace API_MediatR_CQRS.Application.Command
{
    public record DeletePersonCommand(Guid Id) : IRequest<bool>;
}
