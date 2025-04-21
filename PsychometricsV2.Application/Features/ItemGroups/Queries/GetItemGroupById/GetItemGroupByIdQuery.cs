using System;
using MediatR;
using PsychometricsV2.Domain.Entities;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroupById;

public class GetItemGroupByIdQuery : IRequest<ItemGroupDto?>
{
    public Guid Id { get; set; }

    public GetItemGroupByIdQuery(Guid id)
    {
        Id = id;
    }
} 