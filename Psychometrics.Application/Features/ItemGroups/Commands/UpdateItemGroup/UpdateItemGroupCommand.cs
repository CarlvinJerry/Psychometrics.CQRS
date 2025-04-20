using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemGroups.Commands.UpdateItemGroup
{
    /// <summary>
    /// Command to update an ItemGroup
    /// </summary>
    public class UpdateItemGroupCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the ID of the ItemGroup to update
        /// </summary>
        public Guid ItemGroupID { get; set; }

        /// <summary>
        /// Gets or sets the name of the ItemGroup
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the ItemGroup
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the code of the ItemGroup
        /// </summary>
        public string Code { get; set; } = string.Empty;
    }
} 