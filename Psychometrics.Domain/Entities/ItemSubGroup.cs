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

        [Required(ErrorMessage = "Item Group Code is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for Item Type Name is 60 characters.")]
        public string Code { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 200 characters.")]
        public string? Description { get; set; }

        [ForeignKey("ItemGroupID")]
        public virtual ItemGroup? ItemGroups { get; set; }
        public Guid ItemGroupID { get; set; }

        [ForeignKey("ItemSubGroupTypeID")]
        public virtual ItemSubGroupType? ItemSubGroupTypes { get; set; }
        public Guid ItemSubGroupTypeID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 