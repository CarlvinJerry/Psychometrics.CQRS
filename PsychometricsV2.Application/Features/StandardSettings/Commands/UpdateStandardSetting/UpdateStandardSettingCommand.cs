using MediatR;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.UpdateStandardSetting;

public class UpdateStandardSettingCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
} 