using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.Responses.Commands.UpdateResponse;

public class UpdateResponseCommandHandler : IRequestHandler<UpdateResponseCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateResponseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateResponseCommand request, CancellationToken cancellationToken)
    {
        var response = await _context.Responses.FindAsync(new object[] { request.Id }, cancellationToken);

        if (response == null)
        {
            return false;
        }

        // Verify that the Student and Item exist
        var studentExists = await _context.Students.AnyAsync(s => s.StudentId == request.StudentId, cancellationToken);
        if (!studentExists)
        {
            throw new Exception($"Student with ID {request.StudentId} not found.");
        }

        var itemExists = await _context.Items.AnyAsync(i => i.Id == request.ItemId, cancellationToken);
        if (!itemExists)
        {
            throw new Exception($"Item with ID {request.ItemId} not found.");
        }

        response.ResponseValue = request.ResponseValue;
        response.StudentId = request.StudentId;
        response.ItemId = request.ItemId;
        response.CalendarYear = request.CalendarYear;
        response.TeachingPeriod = request.TeachingPeriod;
        response.MscaaId = request.MscaaId;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 