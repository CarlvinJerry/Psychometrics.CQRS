using System;
using MediatR;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.CreateStandardSetting;

public class CreateStandardSettingCommand : IRequest<Guid>
{
    public string Method { get; set; } = null!;
    public string? RecordMonth { get; set; }
    public string? CalendarYear { get; set; }
    public string? AcademicYear { get; set; }
    public string? Category { get; set; }
    public string? Type { get; set; }
    public string? TeachingPeriod { get; set; }
    public int? YearLevel { get; set; }
    public int? Phase { get; set; }
    public double? PassingScore { get; set; }
    public double? EXCScore { get; set; }
    public double? MaxScoreRaw { get; set; }
} 