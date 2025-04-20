using System;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetAllItemSubGroupTypes
{
    /// <summary>
    /// Data transfer object for ItemSubGroupType entities.
    /// </summary>
    public class ItemSubGroupTypeDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ItemSubGroupType.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the code of the ItemSubGroupType.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the ItemSubGroupType.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ItemSubGroupType.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the ItemSubGroupType.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update timestamp of the ItemSubGroupType.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
} 