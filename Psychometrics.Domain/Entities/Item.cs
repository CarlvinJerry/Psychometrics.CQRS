using System;
using System.Collections.Generic;

namespace Psychometrics.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public required string ItemCode { get; set; }
        public required string Question { get; set; }
        public required string CorrectAnswer { get; set; }
        public Guid ItemGroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public required ItemGroup ItemGroup { get; set; }
        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }
} 