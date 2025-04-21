using System;
using System.Collections.Generic;

namespace PsychometricsV2.Domain.Entities;

public class ItemSubGroup : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public Guid ItemGroupId { get; set; }
    public Guid ItemSubGroupTypeId { get; set; }
    public ItemGroup ItemGroup { get; set; } = null!;
    public ItemSubGroupType ItemSubGroupType { get; set; } = null!;
    public ICollection<Item> Items { get; set; } = new List<Item>();
} 