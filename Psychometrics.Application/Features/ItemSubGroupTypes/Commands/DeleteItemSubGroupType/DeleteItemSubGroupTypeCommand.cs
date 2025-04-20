using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.DeleteItemSubGroupType
{
    /// <summary>
    /// Command to delete an existing ItemSubGroupType
    /// </summary>
    public class DeleteItemSubGroupTypeCommand : IRequest<bool>
    {
        /// <summary>
        /// The unique identifier of the ItemSubGroupType to delete
        /// </summary>
        public Guid ItemSubGroupTypeID { get; set; }
    }
} 