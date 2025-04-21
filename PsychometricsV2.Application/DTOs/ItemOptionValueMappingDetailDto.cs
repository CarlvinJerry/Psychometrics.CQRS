using System;

namespace PsychometricsV2.Application.DTOs;

public class ItemOptionValueMappingDetailDto
{
    public Guid Id { get; set; }
    public string ItemOptionValueCode { get; set; } = null!;
    public string ItemOptionCode { get; set; } = null!;
    public string ItemCode { get; set; } = null!;
    public string ItemOptionValueName { get; set; } = null!;
    public string ItemOptionName { get; set; } = null!;
    public string ItemName { get; set; } = null!;
} 