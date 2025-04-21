using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.Students.Queries.GetStudents;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
{
    private readonly IApplicationDbContext _context;

    public GetStudentsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _context.Students
            .Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                CandidateNumber = s.CandidateNumber,
                EmailAddress = s.EmailAddress,
                FirstName = s.FirstName,
                Surname = s.Surname,
                Year = s.Year,
                YearOfEntry = s.YearOfEntry,
                SCJCode = s.SCJCode,
                AcademicYear = s.AcademicYear,
                Block = s.Block,
                ProgressCodeName = s.ProgressCodeName,
                Gender = s.Gender,
                AgeOnEntry = s.AgeOnEntry,
                Ethnicity = s.Ethnicity,
                Disability = s.Disability,
                HighestQualificationOnEntry = s.HighestQualificationOnEntry,
                RegionofDomicile = s.RegionofDomicile,
                Religion = s.Religion,
                SocioEconomicClass = s.SocioEconomicClass,
                PersonalTutor = s.PersonalTutor,
                ExternalTutorEmail = s.ExternalTutorEmail,
                HomeAddress = s.HomeAddress,
                LocalNonLocalWP = s.LocalNonLocalWP,
                DANU = s.DANU,
                Notes = s.Notes
            })
            .ToListAsync(cancellationToken);

        return students;
    }
} 