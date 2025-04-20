using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Candidate Number is a required field.")]
        [MaxLength(10, ErrorMessage = "Maximum length for Candidate Number is 10 characters.")]
        public int CandidateNumber { get; set; }

        [Required(ErrorMessage = "Email Address is a required field.")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "First Name is a required field.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Surname is a required field.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Year is a required field.")]
        [MaxLength(5, ErrorMessage = "Maximum length for Year is 5 characters.")]
        public string? Year { get; set; }

        [Required(ErrorMessage = "Year of Entry is a required field.")]
        public string? YearOfEntry { get; set; }

        public string? SCJCode { get; set; }

        [Required(ErrorMessage = "Academic Year is a required field.")]
        public string? AcademicYear { get; set; }

        [Required(ErrorMessage = "Block is a required field.")]
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

        [Column("ExternalTutorEmail")]
        public string? ExternalTutorEmail { get; set; }

        [Required(ErrorMessage = "HomeAddressWestMidlands is a required field.")]
        public string? HomeAddress { get; set; }

        [Required(ErrorMessage = "LocalNonLocalWP is a required field.")]
        public string? LocalNonLocalWP { get; set; }

        public string? DANU { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<ItemResponse> ItemResponses { get; set; } = new List<ItemResponse>();
    }
} 