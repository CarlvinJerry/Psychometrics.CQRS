using System;
using System.Collections.Generic;

namespace Psychometrics.Domain.Entities
{
    public class ItemSubGroup
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public Guid ItemGroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public required ItemGroup ItemGroup { get; set; }
    }
} 