using MediatR;
using API_MediatR_CQRS.Application.Models;
using System;

namespace API_MediatR_CQRS.Application.Command
{
    public record PersonCommand(string Name, int Age, string TaxId) : IRequest<Person>;
}
