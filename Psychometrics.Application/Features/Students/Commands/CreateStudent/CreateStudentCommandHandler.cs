using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                StudentId = Guid.NewGuid(),
                CandidateNumber = request.CandidateNumber,
                FirstName = request.FirstName,
                Surname = request.Surname,
                EmailAddress = request.EmailAddress,
                Year = request.Year,
                YearOfEntry = request.YearOfEntry,
                SCJCode = request.SCJCode,
                AcademicYear = request.AcademicYear,
                Block = request.Block,
                ProgressCodeName = request.ProgressCodeName,
                Gender = request.Gender,
                AgeOnEntry = request.AgeOnEntry,
                Ethnicity = request.Ethnicity,
                Disability = request.Disability,
                HighestQualificationOnEntry = request.HighestQualificationOnEntry,
                RegionofDomicile = request.RegionofDomicile,
                Religion = request.Religion,
                SocioEconomicClass = request.SocioEconomicClass,
                PersonalTutor = request.PersonalTutor,
                ExternalTutorEmail = request.ExternalTutorEmail,
                HomeAddress = request.HomeAddress,
                LocalNonLocalWP = request.LocalNonLocalWP,
                DANU = request.DANU,
                Notes = request.Notes,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);

            return student.StudentId;
        }
    }
} 