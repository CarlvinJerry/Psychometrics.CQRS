using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychometrics.Domain.Entities
{
    public class ItemSubGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemSubGroupID { get; set; }

        [Required(ErrorMessage = "Item SubGroup Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for Item Type Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Item SubGroup Code is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for Item Type Name is 60 characters.")]
        [Key]
        public string Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 200 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Item Group Code is required.")]
        [MaxLength(50)]
        public string ItemGroupCode { get; set; }

        [ForeignKey("ItemGroupCode")]
        public virtual ItemGroup? ItemGroup { get; set; }

        [Required(ErrorMessage = "Item SubGroup Type Code is required.")]
        [MaxLength(50)]
        public string ItemSubGroupTypeCode { get; set; }

        [ForeignKey("ItemSubGroupTypeCode")]
        public virtual ItemSubGroupType? ItemSubGroupType { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 