using System;
using MediatR;

namespace PsychometricsV2.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup;

public class CreateItemSubGroupCommand : IRequest<Guid>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string ItemGroupCode { get; set; } = null!;
    public string ItemSubGroupTypeCode { get; set; } = null!;
} 