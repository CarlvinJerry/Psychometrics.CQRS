using System;
using MediatR;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.DeleteStandardSetting;

public class DeleteStandardSettingCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 