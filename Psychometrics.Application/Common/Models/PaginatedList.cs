using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Psychometrics.Application.Common.Models
{
    /// <summary>
    /// A generic class for paginated lists.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Gets the page size.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets the total count of items.
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;

        /// <summary>
        /// Gets the items in the current page.
        /// </summary>
        public IReadOnlyCollection<T> Items { get; private set; }

        /// <summary>
        /// Initializes a new instance of the PaginatedList class.
        /// </summary>
        /// <param name="items">The items for the current page.</param>
        /// <param name="count">The total number of items.</param>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The page size.</param>
        public PaginatedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            Items = items.ToList().AsReadOnly();
        }

        /// <summary>
        /// Creates a new instance of PaginatedList from an IQueryable source.
        /// </summary>
        /// <param name="source">The IQueryable source.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the paginated list.</returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
} 