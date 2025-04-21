using System;
using MediatR;

namespace PsychometricsV2.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType;

public class CreateItemSubGroupTypeCommand : IRequest<Guid>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
} 