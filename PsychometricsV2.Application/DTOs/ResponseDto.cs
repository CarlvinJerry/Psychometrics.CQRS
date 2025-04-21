using System;

namespace PsychometricsV2.Application.DTOs;

public class ResponseDto
{
    public int Id { get; set; }
    public decimal ResponseValue { get; set; }
    public int StudentId { get; set; }
    public Guid ItemId { get; set; }
    public int CalendarYear { get; set; }
    public int TeachingPeriod { get; set; }
    public string? MscaaId { get; set; }
    
    // Navigation property DTOs
    public StudentDto? Student { get; set; }
    public ItemDto? Item { get; set; }
} 