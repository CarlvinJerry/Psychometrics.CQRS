using MediatR;
using Microsoft.AspNetCore.Mvc;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Features.StandardSettings.Commands.CreateStandardSetting;
using PsychometricsV2.Application.Features.StandardSettings.Commands.DeleteStandardSetting;
using PsychometricsV2.Application.Features.StandardSettings.Commands.UpdateStandardSetting;
using PsychometricsV2.Application.Features.StandardSettings.Queries.GetStandardSettingById;
using PsychometricsV2.Application.Features.StandardSettings.Queries.GetStandardSettings;

namespace PsychometricsV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StandardSettingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StandardSettingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all standard settings
    /// </summary>
    /// <returns>List of standard settings</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<StandardSettingDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<StandardSettingDto>>> GetAll()
    {
        var standardSettings = await _mediator.Send(new GetStandardSettingsQuery());
        return Ok(standardSettings);
    }

    /// <summary>
    /// Gets a standard setting by ID
    /// </summary>
    /// <param name="id">The standard setting ID</param>
    /// <returns>The standard setting if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(StandardSettingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StandardSettingDto>> Get(int id)
    {
        var standardSetting = await _mediator.Send(new GetStandardSettingByIdQuery { Id = id });
        if (standardSetting == null)
        {
            return NotFound();
        }
        return Ok(standardSetting);
    }

    /// <summary>
    /// Creates a new standard setting
    /// </summary>
    /// <param name="command">The standard setting creation command</param>
    /// <returns>The ID of the created standard setting</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(CreateStandardSettingCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    /// <summary>
    /// Updates an existing standard setting
    /// </summary>
    /// <param name="id">The standard setting ID</param>
    /// <param name="command">The standard setting update command</param>
    /// <returns>No content if successful</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, UpdateStandardSettingCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var success = await _mediator.Send(command);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Deletes a standard setting
    /// </summary>
    /// <param name="id">The standard setting ID</param>
    /// <returns>No content if successful</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteStandardSettingCommand { Id = id });
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
} 