using System;
using MediatR;

namespace Psychometrics.Application.Features.ItemResponses.Commands.CreateResponse;

/// <summary>
/// Command to create a new ItemResponse
/// </summary>
public class CreateResponseCommand : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets the Student Candidate Number
    /// </summary>
    public int StudentCandidateNumber { get; set; }

    /// <summary>
    /// Gets or sets the Item code
    /// </summary>
    public string ItemCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the response value
    /// </summary>
    public decimal ResponseValue { get; set; }

    /// <summary>
    /// Gets or sets the MSCAAID
    /// </summary>
    public string? MSCAAID { get; set; }
} 