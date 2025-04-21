using System;

namespace Psychometrics.Application.Common.DTOs
{
    public class StandardSettingDto
    {
        public Guid Id { get; set; }
        public string Method { get; set; }
        public string RecordMonth { get; set; }
        public string CalendarYear { get; set; }
        public string AcademicYear { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 