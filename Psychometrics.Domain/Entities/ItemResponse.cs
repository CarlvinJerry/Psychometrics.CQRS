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

        [Required]
        public Guid ItemID { get; set; }

        [Required]
        public string StudentCandidateNumber { get; set; }

        [Required]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Response value is a required field.")]
        public decimal ResponseValue { get; set; }

        [MaxLength(50)]
        public string? MSCAAID { get; set; }

        public int CalendarYear { get; set; }

        public int TeachingPeriod { get; set; }

        public DateTime ResponseTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        [ForeignKey("StudentCandidateNumber")]
        public virtual Student Student { get; set; }
    }
} 