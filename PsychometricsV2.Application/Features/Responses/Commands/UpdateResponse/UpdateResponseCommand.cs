using System;
using MediatR;

namespace PsychometricsV2.Application.Features.Responses.Commands.UpdateResponse;

public class UpdateResponseCommand : IRequest<bool>
{
    public int Id { get; set; }
    public decimal ResponseValue { get; set; }
    public int StudentId { get; set; }
    public Guid ItemId { get; set; }
    public int CalendarYear { get; set; }
    public int TeachingPeriod { get; set; }
    public string? MscaaId { get; set; }
} 