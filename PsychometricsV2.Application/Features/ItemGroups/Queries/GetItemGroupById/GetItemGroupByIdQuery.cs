using System;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroupById;

public class GetItemGroupByIdQuery : IRequest<ItemGroup?>
{
    public Guid Id { get; set; }
} 