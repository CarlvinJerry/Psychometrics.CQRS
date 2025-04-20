using System;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetResponseById
{
    public class ResponseDto
    {
        public Guid ResponseId { get; set; }
        public Guid ItemId { get; set; }
        public Guid StudentId { get; set; }
        public string ResponseValue { get; set; }
        public DateTime ResponseTime { get; set; }
    }
} 