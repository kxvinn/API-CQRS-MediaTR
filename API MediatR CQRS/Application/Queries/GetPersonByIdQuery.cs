using MediatR;
using API_MediatR_CQRS.Application.Models;

namespace API_MediatR_CQRS.Application.Queries
{
    public record GetPersonByIdQuery(Guid Id) : IRequest<Person>;
}
