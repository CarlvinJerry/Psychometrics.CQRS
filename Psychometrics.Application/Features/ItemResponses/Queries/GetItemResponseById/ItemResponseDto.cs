using System;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetItemResponseById
{
    public class ItemResponseDto
    {
        public Guid ItemResponseID { get; set; }
        public decimal ResponseValue { get; set; }
        public string? MSCAAID { get; set; }
        public int StudentCandidateNumber { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public int CalendarYear { get; set; }
        public int TeachingPeriod { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public StudentBriefDto Student { get; set; } = null!;
        public ItemBriefDto Item { get; set; } = null!;
    }

    public class StudentBriefDto
    {
        public int CandidateNumber { get; set; }
        public string FullName { get; set; } = string.Empty;
    }

    public class ItemBriefDto
    {
        public string Code { get; set; } = string.Empty;
        public string? Name { get; set; }
    }
} 