using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

namespace Psychometrics.Application.Features.ItemResponses.Commands.CreateResponse;

/// <summary>
/// Handler for creating a new ItemResponse
/// </summary>
public class CreateResponseCommandHandler : IRequestHandler<CreateResponseCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the CreateResponseCommandHandler class
    /// </summary>
    /// <param name="context">The application database context</param>
    public CreateResponseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the request to create a new ItemResponse
    /// </summary>
    /// <param name="request">The command request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The ID of the newly created ItemResponse</returns>
    public async Task<Guid> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        // Validate that Student exists
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.CandidateNumber == request.StudentCandidateNumber, cancellationToken);
        if (student == null)
        {
            throw new NotFoundException(nameof(Student), request.StudentCandidateNumber);
        }

        // Validate that Item exists
        var item = await _context.Items
            .FirstOrDefaultAsync(i => i.Code == request.ItemCode, cancellationToken);
        if (item == null)
        {
            throw new NotFoundException(nameof(Item), request.ItemCode);
        }

        var response = new ItemResponse
        {
            ItemResponseID = Guid.NewGuid(),
            StudentCandidateNumber = request.StudentCandidateNumber,
            ItemCode = request.ItemCode,
            ResponseValue = request.ResponseValue,
            MSCAAID = request.MSCAAID,
            CreatedAt = DateTime.UtcNow,
            Student = student,
            Item = item,
            CalendarYear = DateTime.UtcNow.Year,
            TeachingPeriod = (DateTime.UtcNow.Month <= 6) ? 1 : 2
        };

        _context.ItemResponses.Add(response);
        await _context.SaveChangesAsync(cancellationToken);

        return response.ItemResponseID;
    }
}