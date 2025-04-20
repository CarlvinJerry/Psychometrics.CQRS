using System;
using System.Collections.Generic;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetItemGroupById
{
    public class ItemGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ItemDto> Items { get; set; } = new();
        public List<ItemSubGroupDto> SubGroups { get; set; } = new();
    }

    public class ItemDto
    {
        public Guid Id { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
    }

    public class ItemSubGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
} 