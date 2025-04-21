using System;
using System.Collections.Generic;

namespace PsychometricsV2.Domain.Entities;

public class ItemSubGroupType : BaseEntity
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<ItemSubGroup> ItemSubGroups { get; set; } = new List<ItemSubGroup>();
} 