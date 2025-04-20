using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Psychometrics.Application.Features.Responses.Commands.CreateResponse;
using Psychometrics.Application.Features.Responses.Queries.GetResponseById;
using MediatR;

namespace Psychometrics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResponsesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateResponseCommand command)
        {
            var responseId = await _mediator.Send(command);
            return Ok(responseId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetById(Guid id)
        {
            var query = new GetResponseByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
} 