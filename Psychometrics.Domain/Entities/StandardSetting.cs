using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class StandardSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StandardSettingID { get; set; }

        [Required(ErrorMessage = "Method Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Method is 50 characters.")]
        public string Method { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Maximum length for the record month is 60 characters.")]
        public string RecordMonth { get; set; }

        [Required]
        [MaxLength(4)]
        public string CalendarYear { get; set; }

        [Required]
        [MaxLength(9)]
        public string AcademicYear { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(20)]
        public string TeachingPeriod { get; set; }

        [Required]
        public int YearLevel { get; set; }

        [Required]
        public int Phase { get; set; }

        [Required]
        public double PassingScore { get; set; }

        [Required]
        public double EXCScore { get; set; }

        [Required]
        public double MaxScoreRaw { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 