using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Psychometrics.Application.Features.Items.Commands.CreateItem;
using Psychometrics.Application.Features.Items.Commands.UpdateItem;
using Psychometrics.Application.Features.Items.Commands.DeleteItem;
using Psychometrics.Application.Features.Items.Queries.GetItemById;

namespace Psychometrics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateItemCommand command)
        {
            var itemId = await _mediator.Send(command);
            return Ok(itemId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetById(Guid id)
        {
            var query = new GetItemByIdQuery { Id = id };
            var item = await _mediator.Send(query);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateItemCommand command)
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
            var command = new DeleteItemCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
} 