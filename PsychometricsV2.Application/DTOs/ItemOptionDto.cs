using System;

namespace PsychometricsV2.Application.DTOs;

public class ItemOptionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public string ItemCode { get; set; } = null!;
} 