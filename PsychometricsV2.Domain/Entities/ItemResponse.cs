using System;

namespace PsychometricsV2.Domain.Entities;

public class ItemResponse : BaseEntity
{
    public Guid ItemId { get; set; }
    public Guid ResponseId { get; set; }
    public Item Item { get; set; } = null!;
    public Response Response { get; set; } = null!;
} 