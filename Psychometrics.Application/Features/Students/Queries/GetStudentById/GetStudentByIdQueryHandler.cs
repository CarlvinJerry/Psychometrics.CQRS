using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

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
                .FirstOrDefaultAsync(s => s.CandidateNumber == request.CandidateNumber, cancellationToken);

            if (student == null)
            {
                throw new NotFoundException(nameof(Student), request.CandidateNumber);
            }

            return _mapper.Map<StudentDto>(student);
        }
    }
} 