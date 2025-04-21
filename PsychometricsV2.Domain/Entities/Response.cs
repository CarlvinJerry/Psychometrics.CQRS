using System;

namespace PsychometricsV2.Domain.Entities;

public class Response : BaseEntity
{
    public decimal ResponseValue { get; set; }
    public int StudentId { get; set; }
    public Guid ItemId { get; set; }
    public int CalendarYear { get; set; }
    public int TeachingPeriod { get; set; }
    public string? MscaaId { get; set; }
    public Student Student { get; set; } = null!;
    public Item Item { get; set; } = null!;
    public ICollection<ItemResponse> ItemResponses { get; set; } = new List<ItemResponse>();
} 