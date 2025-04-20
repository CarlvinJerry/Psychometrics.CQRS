using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class ItemResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemResponseID { get; set; }

        [Required(ErrorMessage = "item Response value is a required field.")]
        public decimal ResponseValue { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for MSCAAID is 50 characters.")]
        public string? MSCAAID { get; set; }

        [Required(ErrorMessage = "Student Candidate Number is required.")]
        public int StudentCandidateNumber { get; set; }

        [ForeignKey("StudentCandidateNumber")]
        public virtual Student? Student { get; set; }

        [Required(ErrorMessage = "Item Code is required.")]
        [MaxLength(50)]
        public string ItemCode { get; set; }

        [ForeignKey("ItemCode")]
        public virtual Item? Item { get; set; }

        public int CalendarYear { get; set; }

        public int TeachingPeriod { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 