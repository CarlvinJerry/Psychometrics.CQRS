using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Psychometrics.Domain.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemID { get; set; }

        [Required(ErrorMessage = "Item Code is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Code is 50 characters.")]
        public string Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        /// <summary>
        /// Exam unit
        /// </summary>
        [ForeignKey("ItemSubGroupID")]
        public virtual ItemSubGroup? ItemSubGroups { get; set; }
        public Guid ItemSubGroupID { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public Guid ItemGroupID { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("ItemGroupID")]
        public virtual ItemGroup ItemGroup { get; set; }

        // Navigation properties
        public virtual ICollection<ItemResponse> ItemResponses { get; set; } = new List<ItemResponse>();
    }
} 