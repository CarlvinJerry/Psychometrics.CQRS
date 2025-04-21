using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup;
using PsychometricsV2.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;
using PsychometricsV2.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemSubGroupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemSubGroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemSubGroup>>> GetAll()
    {
        var query = new GetAllItemSubGroupsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemSubGroup>> GetById(Guid id)
    {
        var query = new GetItemSubGroupByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateItemSubGroupCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }
} 