using MediatR;
using System;

namespace Psychometrics.Application.Features.Items.Commands.DeleteItem
{
    /// <summary>
    /// Command to delete an Item
    /// </summary>
    public class DeleteItemCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the ID of the Item to delete
        /// </summary>
        public Guid ItemID { get; set; }
    }
} 