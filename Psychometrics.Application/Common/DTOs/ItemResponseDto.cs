using System;

namespace Psychometrics.Application.Common.DTOs
{
    public class ItemResponseDto
    {
        public Guid ItemResponseID { get; set; }
        public Guid ItemID { get; set; }
        public string StudentCandidateNumber { get; set; }
        public string ItemCode { get; set; }
        public decimal ResponseValue { get; set; }
        public string? MSCAAID { get; set; }
        public int CalendarYear { get; set; }
        public int TeachingPeriod { get; set; }
        public DateTime ResponseTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 