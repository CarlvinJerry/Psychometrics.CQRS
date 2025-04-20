using System;

namespace Psychometrics.Application.Features.Responses.Queries.GetResponseById
{
    public class ResponseDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ItemId { get; set; }
        public required string SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime ResponseTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Related data
        public required StudentBriefDto Student { get; set; }
        public required ItemBriefDto Item { get; set; }
    }

    public class StudentBriefDto
    {
        public Guid Id { get; set; }
        public required string StudentNumber { get; set; }
        public required string FullName { get; set; }
    }

    public class ItemBriefDto
    {
        public Guid Id { get; set; }
        public required string ItemCode { get; set; }
        public required string Question { get; set; }
    }
} 