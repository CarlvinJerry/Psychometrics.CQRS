using System;
using System.Collections.Generic;

namespace Psychometrics.Domain.Entities
{
    public class ItemGroup
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<ItemSubGroup> ItemSubGroups { get; set; } = new List<ItemSubGroup>();
    }
} 