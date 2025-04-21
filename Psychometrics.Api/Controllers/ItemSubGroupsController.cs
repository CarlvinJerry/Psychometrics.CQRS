using Microsoft.AspNetCore.Mvc;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup;
using Psychometrics.Application.Features.ItemSubGroups.Commands.DeleteItemSubGroup;
using Psychometrics.Application.Features.ItemSubGroups.Commands.UpdateItemSubGroup;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById;
using System.Threading.Tasks;

namespace Psychometrics.API.Controllers
{
    public class ItemSubGroupsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ItemSubGroupDto[]>> GetAll()
        {
            return await Mediator.Send(new GetAllItemSubGroupsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemSubGroupDto>> GetById(int id)
        {
            return await Mediator.Send(new GetItemSubGroupByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemSubGroupCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateItemSubGroupCommand command)
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
            await Mediator.Send(new DeleteItemSubGroupCommand { Id = id });
            return NoContent();
        }
    }
} 