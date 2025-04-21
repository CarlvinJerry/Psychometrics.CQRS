using System;

namespace Psychometrics.Application.Common.DTOs
{
    public class ItemSubGroupTypeDto
    {
        public Guid ItemSubGroupTypeID { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 