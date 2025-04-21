using System;

namespace Psychometrics.Application.Common.DTOs
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string CandidateNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Year { get; set; }
        public string YearOfEntry { get; set; }
        public string? SCJCode { get; set; }
        public string AcademicYear { get; set; }
        public int Block { get; set; }
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
        public string HomeAddress { get; set; }
        public string LocalNonLocalWP { get; set; }
        public string? DANU { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 