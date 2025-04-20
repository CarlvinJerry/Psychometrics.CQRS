using MediatR;
using System;

namespace Psychometrics.Application.Features.Items.Commands.UpdateItem
{
    /// <summary>
    /// Command to update an Item
    /// </summary>
    public class UpdateItemCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the ID of the Item to update
        /// </summary>
        public Guid ItemID { get; set; }

        /// <summary>
        /// Gets or sets the code of the Item
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the MSCAA ID of the Item
        /// </summary>
        public string MSCAAID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ItemSubGroup code
        /// </summary>
        public string ItemSubGroupCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ItemGroup code
        /// </summary>
        public string ItemGroupCode { get; set; } = string.Empty;
    }
} 