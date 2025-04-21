namespace PsychometricsV2.Application.DTOs;

public class ItemOptionValueMappingResponseDto
{
    public string ItemOptionValueCode { get; set; } = null!;
    public string ItemOptionCode { get; set; } = null!;
    public string ItemCode { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 