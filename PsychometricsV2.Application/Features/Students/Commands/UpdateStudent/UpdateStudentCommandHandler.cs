using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(new object[] { request.StudentId }, cancellationToken);

        if (student == null)
        {
            return false;
        }

        student.CandidateNumber = request.CandidateNumber;
        student.EmailAddress = request.EmailAddress;
        student.FirstName = request.FirstName;
        student.Surname = request.Surname;
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

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 