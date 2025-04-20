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
        public string Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for MSCAAID is 50 characters.")]
        public string? MSCAAID { get; set; }

        [Required(ErrorMessage = "Item SubGroup Code is required.")]
        [MaxLength(50)]
        public string ItemSubGroupCode { get; set; }

        [ForeignKey("ItemSubGroupCode")]
        public virtual ItemSubGroup? ItemSubGroup { get; set; }

        [Required(ErrorMessage = "Item Group Code is required.")]
        [MaxLength(50)]
        public string ItemGroupCode { get; set; }

        [ForeignKey("ItemGroupCode")]
        public virtual ItemGroup? ItemGroup { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<ItemResponse> ItemResponses { get; set; } = new List<ItemResponse>();
    }
} 