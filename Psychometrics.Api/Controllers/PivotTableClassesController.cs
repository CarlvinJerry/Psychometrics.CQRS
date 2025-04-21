using Microsoft.AspNetCore.Mvc;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Application.Features.PivotTableClasses.Commands.CreatePivotTableClass;
using Psychometrics.Application.Features.PivotTableClasses.Commands.DeletePivotTableClass;
using Psychometrics.Application.Features.PivotTableClasses.Commands.UpdatePivotTableClass;
using Psychometrics.Application.Features.PivotTableClasses.Queries.GetAllPivotTableClasses;
using Psychometrics.Application.Features.PivotTableClasses.Queries.GetPivotTableClassById;
using System.Threading.Tasks;

namespace Psychometrics.API.Controllers
{
    public class PivotTableClassesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PivotTableClassDto[]>> GetAll()
        {
            return await Mediator.Send(new GetAllPivotTableClassesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PivotTableClassDto>> GetById(int id)
        {
            return await Mediator.Send(new GetPivotTableClassByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePivotTableClassCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePivotTableClassCommand command)
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
            await Mediator.Send(new DeletePivotTableClassCommand { Id = id });
            return NoContent();
        }
    }
} 