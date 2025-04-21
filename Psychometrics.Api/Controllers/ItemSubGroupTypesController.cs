using Microsoft.AspNetCore.Mvc;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType;
using Psychometrics.Application.Features.ItemSubGroupTypes.Commands.DeleteItemSubGroupType;
using Psychometrics.Application.Features.ItemSubGroupTypes.Commands.UpdateItemSubGroupType;
using Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetAllItemSubGroupTypes;
using Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById;
using System.Threading.Tasks;

namespace Psychometrics.API.Controllers
{
    public class ItemSubGroupTypesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ItemSubGroupTypeDto[]>> GetAll()
        {
            return await Mediator.Send(new GetAllItemSubGroupTypesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemSubGroupTypeDto>> GetById(int id)
        {
            return await Mediator.Send(new GetItemSubGroupTypeByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemSubGroupTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateItemSubGroupTypeCommand command)
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
            await Mediator.Send(new DeleteItemSubGroupTypeCommand { Id = id });
            return NoContent();
        }
    }
} 