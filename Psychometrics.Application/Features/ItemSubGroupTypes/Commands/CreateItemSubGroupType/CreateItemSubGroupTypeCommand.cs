using System;
using MediatR;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType
{
    /// <summary>
    /// Command to create a new ItemSubGroupType
    /// </summary>
    public class CreateItemSubGroupTypeCommand : IRequest<Guid>
    {
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