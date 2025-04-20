using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using System.Linq;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetItemResponseById
{
    public class GetItemResponseByIdQueryHandler : IRequestHandler<GetItemResponseByIdQuery, ItemResponseDto>
    {
        private readonly IApplicationDbContext _context;

        public GetItemResponseByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemResponseDto> Handle(GetItemResponseByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemResponses
                .Where(x => x.ItemResponseID == request.Id)
                .Select(x => new ItemResponseDto
                {
                    ItemResponseID = x.ItemResponseID,
                    ResponseValue = x.ResponseValue,
                    MSCAAID = x.MSCAAID,
                    StudentCandidateNumber = x.StudentCandidateNumber,
                    ItemCode = x.ItemCode,
                    CalendarYear = x.CalendarYear,
                    TeachingPeriod = x.TeachingPeriod,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .FirstOrDefaultAsync(cancellationToken);

            return entity;
        }
    }
} 