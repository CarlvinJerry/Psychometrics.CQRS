using System;

namespace PsychometricsV2.Application.DTOs;

public class StandardSettingDto
{
    public Guid Id { get; set; }
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
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 