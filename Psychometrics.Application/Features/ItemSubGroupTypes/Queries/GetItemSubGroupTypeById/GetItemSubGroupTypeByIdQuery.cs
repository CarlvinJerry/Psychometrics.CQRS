using System;
using MediatR;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById
{
    /// <summary>
    /// Query to get an ItemSubGroupType by ID
    /// </summary>
    public class GetItemSubGroupTypeByIdQuery : IRequest<ItemSubGroupTypeDto>
    {
        /// <summary>
        /// Gets or sets the ID of the ItemSubGroupType to retrieve
        /// </summary>
        public Guid ItemSubGroupTypeID { get; set; }
    }
} 