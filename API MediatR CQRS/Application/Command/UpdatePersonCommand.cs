using MediatR;

namespace API_MediatR_CQRS.Application.Command
{
    public record UpdatePersonCommand(Guid Id, string Name, int Age, string TaxId) : IRequest<bool>;
}
