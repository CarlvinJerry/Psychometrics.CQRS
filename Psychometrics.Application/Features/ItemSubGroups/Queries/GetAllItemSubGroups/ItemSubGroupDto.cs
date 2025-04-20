using System;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups
{
    /// <summary>
    /// Data transfer object for ItemSubGroup entities.
    /// </summary>
    public class ItemSubGroupDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ItemSubGroup.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ItemSubGroup.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ItemSubGroup.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the parent ItemGroup.
        /// </summary>
        public Guid ItemGroupId { get; set; }

        /// <summary>
        /// Gets or sets the name of the parent ItemGroup.
        /// </summary>
        public string ItemGroupName { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the ItemSubGroup.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update timestamp of the ItemSubGroup.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
} 