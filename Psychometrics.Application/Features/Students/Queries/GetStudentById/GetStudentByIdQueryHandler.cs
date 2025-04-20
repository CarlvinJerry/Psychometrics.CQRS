using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (student == null)
            {
                throw new NotFoundException(nameof(student), request.Id);
            }

            return _mapper.Map<StudentDto>(student);
        }
    }
} 