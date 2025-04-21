using System.Collections.Generic;
using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.StandardSettings.Queries.GetStandardSettings;

public class GetStandardSettingsQuery : IRequest<List<StandardSettingDto>>
{
} 