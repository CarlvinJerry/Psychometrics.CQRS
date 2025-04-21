using MediatR;
using System;

namespace Psychometrics.Application.Features.Students.Commands.UpdateStudent
{
    /// <summary>
    /// Command to update a Student
    /// </summary>
    public class UpdateStudentCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the ID of the Student to update
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Gets or sets the candidate number of the Student
        /// </summary>
        public string CandidateNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the Student
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the surname of the Student
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the Student
        /// </summary>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the year of the Student
        /// </summary>
        public string Year { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the year of entry of the Student
        /// </summary>
        public string YearOfEntry { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the SCJ code of the Student
        /// </summary>
        public string? SCJCode { get; set; }

        /// <summary>
        /// Gets or sets the academic year of the Student
        /// </summary>
        public string AcademicYear { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the block of the Student
        /// </summary>
        public int Block { get; set; }

        /// <summary>
        /// Gets or sets the progress code name of the Student
        /// </summary>
        public string? ProgressCodeName { get; set; }

        /// <summary>
        /// Gets or sets the gender of the Student
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the age on entry of the Student
        /// </summary>
        public int? AgeOnEntry { get; set; }

        /// <summary>
        /// Gets or sets the ethnicity of the Student
        /// </summary>
        public string? Ethnicity { get; set; }

        /// <summary>
        /// Gets or sets the disability of the Student
        /// </summary>
        public string? Disability { get; set; }

        /// <summary>
        /// Gets or sets the highest qualification on entry of the Student
        /// </summary>
        public string? HighestQualificationOnEntry { get; set; }

        /// <summary>
        /// Gets or sets the region of domicile of the Student
        /// </summary>
        public string? RegionofDomicile { get; set; }

        /// <summary>
        /// Gets or sets the religion of the Student
        /// </summary>
        public string? Religion { get; set; }

        /// <summary>
        /// Gets or sets the socio economic class of the Student
        /// </summary>
        public string? SocioEconomicClass { get; set; }

        /// <summary>
        /// Gets or sets the personal tutor of the Student
        /// </summary>
        public string? PersonalTutor { get; set; }

        /// <summary>
        /// Gets or sets the external tutor email of the Student
        /// </summary>
        public string? ExternalTutorEmail { get; set; }

        /// <summary>
        /// Gets or sets the home address of the Student
        /// </summary>
        public string HomeAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the local non local WP of the Student
        /// </summary>
        public string LocalNonLocalWP { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the DANU of the Student
        /// </summary>
        public string? DANU { get; set; }

        /// <summary>
        /// Gets or sets the notes of the Student
        /// </summary>
        public string? Notes { get; set; }
    }
} 