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

        [MaxLength(60, ErrorMessage = "Maximum length for the record month is 60 characters.")]
        public string RecordMonth { get; set; }

        public string CalendarYear { get; set; }

        public string AcademicYear { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public string TeachingPeriod { get; set; }

        public int YearLevel { get; set; }

        public int Phase { get; set; }

        public double PassingScore { get; set; }

        public double EXCScore { get; set; }

        public double MaxScoreRaw { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 