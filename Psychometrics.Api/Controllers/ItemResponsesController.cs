using Microsoft.AspNetCore.Mvc;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Application.Features.ItemResponses.Commands.CreateItemResponse;
using Psychometrics.Application.Features.ItemResponses.Commands.DeleteItemResponse;
using Psychometrics.Application.Features.ItemResponses.Commands.UpdateItemResponse;
using Psychometrics.Application.Features.ItemResponses.Queries.GetAllItemResponses;
using Psychometrics.Application.Features.ItemResponses.Queries.GetItemResponseById;
using System.Threading.Tasks;

namespace Psychometrics.API.Controllers
{
    public class ItemResponsesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ItemResponseDto[]>> GetAll()
        {
            return await Mediator.Send(new GetAllItemResponsesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponseDto>> GetById(int id)
        {
            return await Mediator.Send(new GetItemResponseByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemResponseCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateItemResponseCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteItemResponseCommand { Id = id });
            return NoContent();
        }
    }
} 