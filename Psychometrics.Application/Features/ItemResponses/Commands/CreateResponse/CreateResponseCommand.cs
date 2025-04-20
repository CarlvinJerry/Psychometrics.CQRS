using System;
using MediatR;

namespace Psychometrics.Application.Features.ItemResponses.Commands.CreateResponse;

/// <summary>
/// Command to create a new ItemResponse
/// </summary>
public class CreateResponseCommand : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets the Item code
    /// </summary>
    public string ItemCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Student ID
    /// </summary>
    public Guid StudentId { get; set; }

    /// <summary>
    /// Gets or sets the response value
    /// </summary>
    public string Response { get; set; } = string.Empty;
} 