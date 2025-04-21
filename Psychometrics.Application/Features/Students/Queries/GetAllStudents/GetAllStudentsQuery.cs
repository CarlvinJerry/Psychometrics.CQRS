using MediatR;
using System;
using System.Collections.Generic;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.Students.Queries.GetAllStudents
{
    /// <summary>
    /// Query to retrieve a paginated list of students with optional filtering and sorting.
    /// </summary>
    public class GetAllStudentsQuery : IRequest<PaginatedList<StudentDto>>
    {
        /// <summary>
        /// Gets or sets the search term to filter students.
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
    }
} 