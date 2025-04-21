using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class ItemSubGroupType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemSubGroupTypeID { get; set; }

        [Required(ErrorMessage = "ItemSubGroupType Code is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Code is 50 characters.")]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [MaxLength(200, ErrorMessage = "Maximum length for the Description is 200 characters.")]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<ItemSubGroup> ItemSubGroups { get; set; } = new List<ItemSubGroup>();
    }
} 