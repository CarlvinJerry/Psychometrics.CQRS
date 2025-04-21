using MediatR;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.UpdateItemGroup;

public class UpdateItemGroupCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
} 