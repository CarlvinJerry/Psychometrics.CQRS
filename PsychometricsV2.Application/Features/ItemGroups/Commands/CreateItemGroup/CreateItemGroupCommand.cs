using System;
using MediatR;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.CreateItemGroup;

public class CreateItemGroupCommand : IRequest<Guid>
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
} 