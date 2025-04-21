using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType;
using PsychometricsV2.Application.Features.ItemSubGroupTypes.Queries.GetAllItemSubGroupTypes;
using PsychometricsV2.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemSubGroupTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemSubGroupTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemSubGroupType>>> GetAll()
    {
        var query = new GetAllItemSubGroupTypesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemSubGroupType>> GetById(Guid id)
    {
        var query = new GetItemSubGroupTypeByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateItemSubGroupTypeCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }
} 