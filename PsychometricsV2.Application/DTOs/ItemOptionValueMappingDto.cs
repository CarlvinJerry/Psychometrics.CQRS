using System;

namespace PsychometricsV2.Application.DTOs;

public class ItemOptionValueMappingDto
{
    public Guid Id { get; set; }
    public string ItemOptionValueCode { get; set; } = null!;
    public string ItemOptionCode { get; set; } = null!;
    public string ItemCode { get; set; } = null!;
} 