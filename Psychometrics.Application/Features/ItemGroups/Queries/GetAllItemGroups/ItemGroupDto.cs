using System;
using System.Collections.Generic;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetAllItemGroups
{
    public class ItemGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ItemCount { get; set; }
        public int SubGroupCount { get; set; }
    }
} 