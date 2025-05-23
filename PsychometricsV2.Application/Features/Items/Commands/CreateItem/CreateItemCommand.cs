using System;
using MediatR;

namespace PsychometricsV2.Application.Features.Items.Commands.CreateItem;

public class CreateItemCommand : IRequest<Guid>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string ItemSubGroupCode { get; set; } = null!;
} 