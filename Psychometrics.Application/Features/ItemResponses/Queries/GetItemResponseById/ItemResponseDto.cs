using System;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetItemResponseById
{
    public class ItemResponseDto
    {
        public Guid ItemResponseID { get; set; }
        public decimal ResponseValue { get; set; }
        public string? MSCAAID { get; set; }
        public int StudentCandidateNumber { get; set; }
        public string ItemCode { get; set; }
        public int CalendarYear { get; set; }
        public int TeachingPeriod { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 