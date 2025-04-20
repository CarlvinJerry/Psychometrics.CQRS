using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemResponses.Commands.CreateItemResponse
{
    public class CreateItemResponseCommandHandler : IRequestHandler<CreateItemResponseCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemResponseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateItemResponseCommand request, CancellationToken cancellationToken)
        {
            var entity = new ItemResponse
            {
                ResponseValue = request.ResponseValue,
                MSCAAID = request.MSCAAID,
                StudentCandidateNumber = request.StudentCandidateNumber,
                ItemCode = request.ItemCode,
                CalendarYear = request.CalendarYear,
                TeachingPeriod = request.TeachingPeriod,
                CreatedAt = DateTime.UtcNow
            };

            _context.ItemResponses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.ItemResponseID;
        }
    }
} 