using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Psychometrics.Application.Features.Students.Commands.CreateStudent;
using Psychometrics.Application.Features.Students.Queries.GetStudentById;
using MediatR;

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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateStudentCommand command)
        {
            var studentId = await _mediator.Send(command);
            return Ok(studentId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(Guid id)
        {
            var query = new GetStudentByIdQuery { Id = id };
            var student = await _mediator.Send(query);
            return Ok(student);
        }
    }
} 