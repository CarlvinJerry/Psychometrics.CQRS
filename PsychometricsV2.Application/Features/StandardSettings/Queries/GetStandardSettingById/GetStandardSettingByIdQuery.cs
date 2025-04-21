using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.StandardSettings.Queries.GetStandardSettingById;

public class GetStandardSettingByIdQuery : IRequest<StandardSettingDto?>
{
    public int Id { get; set; }
} 