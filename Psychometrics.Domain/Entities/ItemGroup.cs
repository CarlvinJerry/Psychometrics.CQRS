using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class ItemGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemGroupID { get; set; }

        [Required(ErrorMessage = "Item Group Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for Item Type Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Item Group Code is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for Item Type Name is 60 characters.")]
        public string Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Description is 200 characters.")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<ItemSubGroup> ItemSubGroups { get; set; } = new List<ItemSubGroup>();
    }
} 