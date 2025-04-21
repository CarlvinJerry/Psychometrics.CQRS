using Microsoft.AspNetCore.Mvc;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Application.Features.StandardSettings.Commands.CreateStandardSetting;
using Psychometrics.Application.Features.StandardSettings.Commands.DeleteStandardSetting;
using Psychometrics.Application.Features.StandardSettings.Commands.UpdateStandardSetting;
using Psychometrics.Application.Features.StandardSettings.Queries.GetAllStandardSettings;
using Psychometrics.Application.Features.StandardSettings.Queries.GetStandardSettingById;
using System.Threading.Tasks;

namespace Psychometrics.API.Controllers
{
    public class StandardSettingsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<StandardSettingDto[]>> GetAll()
        {
            return await Mediator.Send(new GetAllStandardSettingsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StandardSettingDto>> GetById(int id)
        {
            return await Mediator.Send(new GetStandardSettingByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateStandardSettingCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStandardSettingCommand command)
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
            await Mediator.Send(new DeleteStandardSettingCommand { Id = id });
            return NoContent();
        }
    }
} 