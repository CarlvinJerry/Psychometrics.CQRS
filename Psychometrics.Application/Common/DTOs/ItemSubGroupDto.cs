using System;

namespace Psychometrics.Application.Common.DTOs
{
    public class ItemSubGroupDto
    {
        public Guid ItemSubGroupID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public Guid ItemGroupID { get; set; }
        public Guid ItemSubGroupTypeID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 