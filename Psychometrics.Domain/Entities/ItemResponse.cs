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

        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for MSCAAID is 50 characters.")]
        public string? MSCAAID { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student? Students { get; set; }
        public Guid StudentId { get; set; }

        [ForeignKey("ItemID")]
        public virtual Item? Items { get; set; }
        public Guid ItemID { get; set; }

        public int CalendarYear { get; set; }

        public int TeachingPeriod { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 