using MediatR;
using System;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups
{
    /// <summary>
    /// Query to retrieve a paginated list of ItemSubGroups with optional filtering and sorting.
    /// </summary>
    public class GetAllItemSubGroupsQuery : IRequest<PaginatedList<ItemSubGroupDto>>
    {
        /// <summary>
        /// Gets or sets the search term to filter ItemSubGroups.
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the property name to sort by.
        /// </summary>
        public string? SortBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to sort in descending order.
        /// </summary>
        public bool SortDescending { get; set; }

        /// <summary>
        /// Gets or sets the page number (1-based). Defaults to 1.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size. Defaults to 10.
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Gets or sets the optional ItemGroup ID to filter by.
        /// </summary>
        public Guid? ItemGroupId { get; set; }
    }
} 