using MediatR;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            CandidateNumber = request.CandidateNumber,
            EmailAddress = request.EmailAddress,
            FirstName = request.FirstName,
            Surname = request.Surname,
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
            Notes = request.Notes
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync(cancellationToken);

        return student.StudentId;
    }
} 