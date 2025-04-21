using System;
using System.Collections.Generic;

namespace PsychometricsV2.Domain.Entities;

public class ItemGroup : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<ItemSubGroup> ItemSubGroups { get; set; } = new List<ItemSubGroup>();
} 