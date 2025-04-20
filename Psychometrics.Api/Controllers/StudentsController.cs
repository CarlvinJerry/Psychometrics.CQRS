using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Psychometrics.Application.Features.Students.Commands.CreateStudent;
using Psychometrics.Application.Features.Students.Commands.UpdateStudent;
using Psychometrics.Application.Features.Students.Commands.DeleteStudent;
using Psychometrics.Application.Features.Students.Queries.GetStudentById;
using Psychometrics.Application.Features.Students.Queries.GetAllStudents;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<StudentDto>>> GetAll([FromQuery] GetAllStudentsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(Guid id)
        {
            var query = new GetStudentByIdQuery { Id = id };
            var student = await _mediator.Send(query);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateStudentCommand command)
        {
            var studentId = await _mediator.Send(command);
            return Ok(studentId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteStudentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
} 