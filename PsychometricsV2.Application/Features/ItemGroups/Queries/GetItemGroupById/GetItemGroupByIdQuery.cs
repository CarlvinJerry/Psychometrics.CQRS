using System;
using MediatR;
using PsychometricsV2.Domain.Entities;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroupById;

public class GetItemGroupByIdQuery : IRequest<ItemGroupDto?>
{
    public int Id { get; set; }

    public GetItemGroupByIdQuery(int id)
    {
        Id = id;
    }
} 