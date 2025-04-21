using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ResponseId { get; set; }

        [Required(ErrorMessage = "item Response value is a required field.")]
        public decimal ResponseValue { get; set; }

        public int Id { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student? Students { get; set; }
        public Guid StudentId { get; set; }

        /// <summary>
        /// Unit
        /// </summary>
        [ForeignKey("ItemID")]
        public virtual Item? Items { get; set; }
        public Guid ItemID { get; set; }

        public int CalendarYear { get; set; }

        public int TeachingPeriod { get; set; }
    }
} 