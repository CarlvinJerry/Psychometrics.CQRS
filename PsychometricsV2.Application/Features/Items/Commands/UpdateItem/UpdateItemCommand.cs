using System;
using MediatR;

namespace PsychometricsV2.Application.Features.Items.Commands.UpdateItem;

public class UpdateItemCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Guid ItemSubGroupId { get; set; }
} 