using System;
using MediatR;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById
{
    /// <summary>
    /// Query to retrieve a specific ItemSubGroup by its ID.
    /// </summary>
    public class GetItemSubGroupByIdQuery : IRequest<ItemSubGroupDto>
    {
        /// <summary>
        /// Gets or sets the ID of the ItemSubGroup to retrieve.
        /// </summary>
        public Guid ItemSubGroupId { get; set; }
    }
} 