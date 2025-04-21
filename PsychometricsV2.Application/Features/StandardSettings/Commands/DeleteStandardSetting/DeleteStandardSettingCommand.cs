using MediatR;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.DeleteStandardSetting;

public class DeleteStandardSettingCommand : IRequest<bool>
{
    public int Id { get; set; }
} 