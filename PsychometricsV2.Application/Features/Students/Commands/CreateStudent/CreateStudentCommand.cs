using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentCommand : IRequest<int>
{
    public int CandidateNumber { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Year { get; set; } = null!;
    public string YearOfEntry { get; set; } = null!;
    public string? SCJCode { get; set; }
    public string AcademicYear { get; set; } = null!;
    public int Block { get; set; }
    public string? ProgressCodeName { get; set; }
    public string? Gender { get; set; }
    public int AgeOnEntry { get; set; }
    public string? Ethnicity { get; set; }
    public string? Disability { get; set; }
    public string? HighestQualificationOnEntry { get; set; }
    public string? RegionofDomicile { get; set; }
    public string? Religion { get; set; }
    public string? SocioEconomicClass { get; set; }
    public string? PersonalTutor { get; set; }
    public string? ExternalTutorEmail { get; set; }
    public string HomeAddress { get; set; } = null!;
    public string LocalNonLocalWP { get; set; } = null!;
    public string? DANU { get; set; }
    public string? Notes { get; set; }
} 