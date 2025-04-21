using System;
using System.Collections.Generic;

namespace PsychometricsV2.Domain.Entities;

public class Item : BaseEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? MscaaId { get; set; }
    public Guid ItemSubGroupId { get; set; }
    public ItemSubGroup ItemSubGroup { get; set; } = null!;
    public ICollection<ItemResponse> ItemResponses { get; set; } = new List<ItemResponse>();
} 