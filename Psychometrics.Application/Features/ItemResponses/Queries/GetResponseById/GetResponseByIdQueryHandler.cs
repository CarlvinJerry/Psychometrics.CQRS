using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Exceptions;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetResponseById
{
    public class GetResponseByIdQueryHandler : IRequestHandler<GetResponseByIdQuery, ResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetResponseByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto> Handle(GetResponseByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.ItemResponses
                .Include(r => r.Item)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(r => r.ItemResponseID == request.ItemResponseID, cancellationToken);

            if (response == null)
            {
                throw new NotFoundException(nameof(ItemResponse), request.ItemResponseID);
            }

            return _mapper.Map<ResponseDto>(response);
        }
    }
} 