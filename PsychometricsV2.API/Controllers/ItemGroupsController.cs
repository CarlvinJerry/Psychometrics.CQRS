using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Features.ItemGroups.Commands.CreateItemGroup;
using PsychometricsV2.Application.Features.ItemGroups.Commands.DeleteItemGroup;
using PsychometricsV2.Application.Features.ItemGroups.Commands.UpdateItemGroup;
using PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroupById;
using PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroups;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.API.Controllers;

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
    public async Task<ActionResult<List<ItemGroupDto>>> GetAll()
    {
        var query = new GetItemGroupsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemGroupDto>> GetById(Guid id)
    {
        var query = new GetItemGroupByIdQuery(id);
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateItemGroupCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }
} 