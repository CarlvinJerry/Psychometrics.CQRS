using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Responses.Commands.CreateResponse
{
    public class CreateResponseCommandHandler : IRequestHandler<CreateResponseCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateResponseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
        {
            // Validate that Student exists
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);
            if (student == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }

            // Validate that Item exists
            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == request.ItemId, cancellationToken);
            if (item == null)
            {
                throw new NotFoundException(nameof(Item), request.ItemId);
            }

            var response = new Response
            {
                Id = Guid.NewGuid(),
                StudentId = request.StudentId,
                ItemId = request.ItemId,
                SelectedAnswer = request.SelectedAnswer,
                IsCorrect = request.IsCorrect,
                ResponseTime = request.ResponseTime,
                CreatedAt = DateTime.UtcNow,
                Student = student,
                Item = item
            };

            _context.Responses.Add(response);
            await _context.SaveChangesAsync(cancellationToken);

            return response.Id;
        }
    }
} 