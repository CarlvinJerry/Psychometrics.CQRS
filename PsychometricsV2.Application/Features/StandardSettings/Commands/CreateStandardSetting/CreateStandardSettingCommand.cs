using MediatR;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.CreateStandardSetting;

public class CreateStandardSettingCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
} 