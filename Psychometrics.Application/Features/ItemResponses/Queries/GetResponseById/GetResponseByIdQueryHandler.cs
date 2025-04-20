using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetResponseById
{
    public class GetResponseByIdQueryHandler : IRequestHandler<GetResponseByIdQuery, ResponseDto>
    {
        private readonly IApplicationDbContext _context;

        public GetResponseByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto> Handle(GetResponseByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Responses
                .FirstOrDefaultAsync(r => r.ResponseId == request.ResponseId, cancellationToken);

            if (response == null)
            {
                return null;
            }

            return new ResponseDto
            {
                ResponseId = response.ResponseId,
                ItemId = response.ItemId,
                StudentId = response.StudentId,
                ResponseValue = response.ResponseValue,
                ResponseTime = response.ResponseTime
            };
        }
    }
} 