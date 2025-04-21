using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Responses.Commands.CreateResponse;

public class CreateResponseCommandHandler : IRequestHandler<CreateResponseCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateResponseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
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

        var response = new Response
        {
            ResponseValue = request.ResponseValue,
            StudentId = request.StudentId,
            ItemId = request.ItemId,
            CalendarYear = request.CalendarYear,
            TeachingPeriod = request.TeachingPeriod,
            MscaaId = request.MscaaId
        };

        _context.Responses.Add(response);
        await _context.SaveChangesAsync(cancellationToken);

        return response.Id;
    }
} 