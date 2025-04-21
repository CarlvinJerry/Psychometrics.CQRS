using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Psychometrics.Domain.Entities
{
    [Index(nameof(CandidateNumber), IsUnique = true)]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }

        [Required(ErrorMessage = "Candidate Number is a required field.")]
        [MaxLength(10, ErrorMessage = "Maximum length for Candidate Number is 10 characters.")]
        public string CandidateNumber { get; set; }

        [Required(ErrorMessage = "Email Address is a required field.")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "First Name is a required field.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is a required field.")]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Year is a required field.")]
        [MaxLength(5, ErrorMessage = "Maximum length for Year is 5 characters.")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Year of Entry is a required field.")]
        [MaxLength(4)]
        public string YearOfEntry { get; set; }

        [MaxLength(20)]
        public string? SCJCode { get; set; }

        [Required(ErrorMessage = "Academic Year is a required field.")]
        [MaxLength(9)]
        public string AcademicYear { get; set; }

        [Required(ErrorMessage = "Block is a required field.")]
        public int Block { get; set; }

        [MaxLength(50)]
        public string? ProgressCodeName { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        public int? AgeOnEntry { get; set; }

        [MaxLength(50)]
        public string? Ethnicity { get; set; }

        [MaxLength(50)]
        public string? Disability { get; set; }

        [MaxLength(100)]
        public string? HighestQualificationOnEntry { get; set; }

        [MaxLength(100)]
        public string? RegionofDomicile { get; set; }

        [MaxLength(50)]
        public string? Religion { get; set; }

        [MaxLength(50)]
        public string? SocioEconomicClass { get; set; }

        [MaxLength(100)]
        public string? PersonalTutor { get; set; }

        [EmailAddress]
        [Column("ExternalTutorEmail")]
        public string? ExternalTutorEmail { get; set; }

        [Required(ErrorMessage = "HomeAddressWestMidlands is a required field.")]
        [MaxLength(200)]
        public string HomeAddress { get; set; }

        [Required(ErrorMessage = "LocalNonLocalWP is a required field.")]
        [MaxLength(20)]
        public string LocalNonLocalWP { get; set; }

        [MaxLength(20)]
        public string? DANU { get; set; }

        public string? Notes { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<ItemResponse> ItemResponses { get; set; } = new List<ItemResponse>();
    }
} 