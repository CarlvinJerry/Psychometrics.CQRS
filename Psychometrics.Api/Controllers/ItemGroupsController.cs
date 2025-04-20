using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Psychometrics.Application.Features.ItemGroups.Commands.CreateItemGroup;
using Psychometrics.Application.Features.ItemGroups.Commands.UpdateItemGroup;
using Psychometrics.Application.Features.ItemGroups.Commands.DeleteItemGroup;
using Psychometrics.Application.Features.ItemGroups.Queries.GetAllItemGroups;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ItemGroupDto>>> GetAll([FromQuery] GetAllItemGroupsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateItemGroupCommand command)
        {
            var itemGroupId = await _mediator.Send(command);
            return Ok(itemGroupId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateItemGroupCommand command)
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
            var command = new DeleteItemGroupCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
} 