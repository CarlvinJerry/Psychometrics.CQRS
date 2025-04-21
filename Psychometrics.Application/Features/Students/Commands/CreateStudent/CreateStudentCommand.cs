using System;
using MediatR;

namespace Psychometrics.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<Guid>
    {
        public required string CandidateNumber { get; set; }
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        public required string EmailAddress { get; set; }
        public required string Year { get; set; }
        public required string YearOfEntry { get; set; }
        public string? SCJCode { get; set; }
        public required string AcademicYear { get; set; }
        public required int Block { get; set; }
        public string? ProgressCodeName { get; set; }
        public string? Gender { get; set; }
        public int? AgeOnEntry { get; set; }
        public string? Ethnicity { get; set; }
        public string? Disability { get; set; }
        public string? HighestQualificationOnEntry { get; set; }
        public string? RegionofDomicile { get; set; }
        public string? Religion { get; set; }
        public string? SocioEconomicClass { get; set; }
        public string? PersonalTutor { get; set; }
        public string? ExternalTutorEmail { get; set; }
        public required string HomeAddress { get; set; }
        public required string LocalNonLocalWP { get; set; }
        public string? DANU { get; set; }
        public string? Notes { get; set; }
    }
} 