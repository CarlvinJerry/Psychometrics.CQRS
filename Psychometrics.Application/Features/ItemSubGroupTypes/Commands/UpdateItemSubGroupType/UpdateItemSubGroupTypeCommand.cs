using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.UpdateItemSubGroupType
{
    /// <summary>
    /// Command to update an existing ItemSubGroupType
    /// </summary>
    public class UpdateItemSubGroupTypeCommand : IRequest<bool>
    {
        /// <summary>
        /// The unique identifier of the ItemSubGroupType to update
        /// </summary>
        public Guid ItemSubGroupTypeID { get; set; }

        /// <summary>
        /// The code of the ItemSubGroupType
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The name of the ItemSubGroupType (optional)
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description of the ItemSubGroupType (optional)
        /// </summary>
        public string? Description { get; set; }
    }
} 