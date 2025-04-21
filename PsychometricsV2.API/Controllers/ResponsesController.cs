using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Features.Responses.Commands.CreateResponse;
using PsychometricsV2.Application.Features.Responses.Commands.DeleteResponse;
using PsychometricsV2.Application.Features.Responses.Commands.UpdateResponse;
using PsychometricsV2.Application.Features.Responses.Queries.GetResponseById;
using PsychometricsV2.Application.Features.Responses.Queries.GetResponses;

namespace PsychometricsV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponsesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all responses
    /// </summary>
    /// <returns>List of responses</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ResponseDto>>> GetAll()
    {
        var responses = await _mediator.Send(new GetResponsesQuery());
        return Ok(responses);
    }

    /// <summary>
    /// Gets a response by ID
    /// </summary>
    /// <param name="id">The response ID</param>
    /// <returns>The response if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseDto>> Get(Guid id)
    {
        var response = await _mediator.Send(new GetResponseByIdQuery(id));
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    /// <summary>
    /// Creates a new response
    /// </summary>
    /// <param name="command">The response creation command</param>
    /// <returns>The ID of the created response</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(CreateResponseCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    /// <summary>
    /// Updates an existing response
    /// </summary>
    /// <param name="id">The response ID</param>
    /// <param name="command">The response update command</param>
    /// <returns>No content if successful</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateResponseCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes a response
    /// </summary>
    /// <param name="id">The response ID</param>
    /// <returns>No content if successful</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteResponseCommand(id));
        return NoContent();
    }
} 