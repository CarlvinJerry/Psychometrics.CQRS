using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemResponses.Commands.UpdateItemResponse
{
    public class UpdateItemResponseCommandHandler : IRequestHandler<UpdateItemResponseCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateItemResponseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateItemResponseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemResponses.FindAsync(request.ItemResponseID);

            if (entity == null)
            {
                return false;
            }

            entity.ResponseValue = request.ResponseValue;
            entity.MSCAAID = request.MSCAAID;
            entity.StudentCandidateNumber = request.StudentCandidateNumber;
            entity.ItemCode = request.ItemCode;
            entity.CalendarYear = request.CalendarYear;
            entity.TeachingPeriod = request.TeachingPeriod;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 