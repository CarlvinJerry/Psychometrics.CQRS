using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

namespace Psychometrics.Application.Features.Students.Commands.UpdateStudent
{
    /// <summary>
    /// Handler for the UpdateStudentCommand
    /// </summary>
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateStudentCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the UpdateStudentCommand
        /// </summary>
        /// <param name="request">The update student command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A boolean indicating whether the update was successful</returns>
        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentId == request.StudentId, cancellationToken);

            if (student == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }

            student.CandidateNumber = request.CandidateNumber;
            student.FirstName = request.FirstName;
            student.Surname = request.Surname;
            student.EmailAddress = request.EmailAddress;
            student.Year = request.Year;
            student.YearOfEntry = request.YearOfEntry;
            student.SCJCode = request.SCJCode;
            student.AcademicYear = request.AcademicYear;
            student.Block = request.Block;
            student.ProgressCodeName = request.ProgressCodeName;
            student.Gender = request.Gender;
            student.AgeOnEntry = request.AgeOnEntry;
            student.Ethnicity = request.Ethnicity;
            student.Disability = request.Disability;
            student.HighestQualificationOnEntry = request.HighestQualificationOnEntry;
            student.RegionofDomicile = request.RegionofDomicile;
            student.Religion = request.Religion;
            student.SocioEconomicClass = request.SocioEconomicClass;
            student.PersonalTutor = request.PersonalTutor;
            student.ExternalTutorEmail = request.ExternalTutorEmail;
            student.HomeAddress = request.HomeAddress;
            student.LocalNonLocalWP = request.LocalNonLocalWP;
            student.DANU = request.DANU;
            student.Notes = request.Notes;
            student.UpdatedAt = System.DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 