using Microsoft.AspNetCore.Mvc;
using MediatR;
using API_MediatR_CQRS.Application.Models;
using API_MediatR_CQRS.Application.Queries;
using API_MediatR_CQRS.Application.Command;



namespace API_MediatR_CQRS.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _mediator.Send(new GetPersonsQuery());
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery(id));

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Guid id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest("teste");
            }

            var result = await _mediator.Send(new UpdatePersonCommand(id, person.Name, person.Age, person.TaxId));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson([FromBody] Person person)
        {
            var createdPerson = await _mediator.Send(new PersonCommand(person.Name, person.Age, person.TaxId));
            return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var result = await _mediator.Send(new DeletePersonCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
