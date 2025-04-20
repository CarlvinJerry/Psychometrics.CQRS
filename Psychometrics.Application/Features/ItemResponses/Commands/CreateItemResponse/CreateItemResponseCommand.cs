using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemResponses.Commands.CreateItemResponse
{
    public class CreateItemResponseCommand : IRequest<Guid>
    {
        public decimal ResponseValue { get; set; }
        public string? MSCAAID { get; set; }
        public int StudentCandidateNumber { get; set; }
        public string ItemCode { get; set; }
        public int CalendarYear { get; set; }
        public int TeachingPeriod { get; set; }
    }
} 