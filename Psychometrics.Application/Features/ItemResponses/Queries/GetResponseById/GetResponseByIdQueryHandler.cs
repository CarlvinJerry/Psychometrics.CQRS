using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Responses.Queries.GetResponseById
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
            var response = await _context.Responses
                .Include(r => r.Student)
                .Include(r => r.Item)
                .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (response == null)
            {
                throw new NotFoundException(nameof(response), request.Id);
            }

            return _mapper.Map<ResponseDto>(response);
        }
    }
} 