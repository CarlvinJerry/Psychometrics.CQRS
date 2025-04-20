using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemID { get; set; }

        [Required(ErrorMessage = "Item Code is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Code is 50 characters.")]
        public string? Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for MSCAAID is 50 characters.")]
        public string? MSCAAID { get; set; }

        [ForeignKey("ItemSubGroupID")]
        public virtual ItemSubGroup? ItemSubGroups { get; set; }
        public Guid ItemSubGroupID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public required ItemGroup ItemGroup { get; set; }
        public ICollection<ItemResponse> ItemResponses { get; set; } = new List<ItemResponse>();
    }
} 