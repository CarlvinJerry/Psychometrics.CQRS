using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Psychometrics.Domain.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class ItemSubGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemSubGroupID { get; set; }

        [Required(ErrorMessage = "Item SubGroup Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for Item Type Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Item Group Code is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for Item Type Name is 60 characters.")]
        public string Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 200 characters.")]
        public string? Description { get; set; }

        [Required]
        public Guid ItemGroupID { get; set; }

        [Required]
        public Guid ItemSubGroupTypeID { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("ItemGroupID")]
        public virtual ItemGroup ItemGroup { get; set; }

        [ForeignKey("ItemSubGroupTypeID")]
        public virtual ItemSubGroupType ItemSubGroupType { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
} 