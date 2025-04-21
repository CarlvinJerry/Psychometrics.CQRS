using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups
{
    /// <summary>
    /// Handler for processing GetAllItemSubGroupsQuery requests.
    /// </summary>
    public class GetAllItemSubGroupsQueryHandler : IRequestHandler<GetAllItemSubGroupsQuery, PaginatedList<ItemSubGroupDto>>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the GetAllItemSubGroupsQueryHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public GetAllItemSubGroupsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the retrieval of a paginated list of ItemSubGroups with optional filtering and sorting.
        /// </summary>
        /// <param name="request">The query containing filtering, sorting, and pagination parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paginated list of ItemSubGroupDto objects.</returns>
        public async Task<PaginatedList<ItemSubGroupDto>> Handle(GetAllItemSubGroupsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.ItemSubGroups
                .Include(isg => isg.ItemGroup)
                .Include(isg => isg.ItemSubGroupType)
                .AsQueryable();

            // Filter by ItemGroupId if provided
            if (request.ItemGroupId.HasValue)
            {
                query = query.Where(isg => isg.ItemGroupID == request.ItemGroupId.Value);
            }

            // Apply search filter if provided
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(isg =>
                    isg.Name.ToLower().Contains(searchTerm) ||
                    (isg.Description != null && isg.Description.ToLower().Contains(searchTerm)) ||
                    isg.ItemGroup.Name.ToLower().Contains(searchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                query = request.SortBy.ToLower() switch
                {
                    "name" => request.SortDescending ? 
                        query.OrderByDescending(isg => isg.Name) : 
                        query.OrderBy(isg => isg.Name),
                    "description" => request.SortDescending ? 
                        query.OrderByDescending(isg => isg.Description) : 
                        query.OrderBy(isg => isg.Description),
                    "itemgroupname" => request.SortDescending ? 
                        query.OrderByDescending(isg => isg.ItemGroup.Name) : 
                        query.OrderBy(isg => isg.ItemGroup.Name),
                    "createdat" => request.SortDescending ? 
                        query.OrderByDescending(isg => isg.CreatedAt) : 
                        query.OrderBy(isg => isg.CreatedAt),
                    _ => query.OrderByDescending(isg => isg.CreatedAt)
                };
            }
            else
            {
                // Default sorting by creation date
                query = query.OrderByDescending(isg => isg.CreatedAt);
            }

            // Project to DTO
            var dtoQuery = query.Select(isg => new ItemSubGroupDto
            {
                ItemSubGroupID = isg.ItemSubGroupID,
                Name = isg.Name,
                Code = isg.Code,
                Description = isg.Description,
                ItemGroupID = isg.ItemGroupID,
                ItemGroupName = isg.ItemGroup.Name,
                ItemSubGroupTypeID = isg.ItemSubGroupTypeID,
                ItemSubGroupTypeName = isg.ItemSubGroupType.Name ?? string.Empty,
                IsActive = isg.IsActive,
                CreatedAt = isg.CreatedAt,
                UpdatedAt = isg.UpdatedAt
            });

            // Apply pagination
            return await PaginatedList<ItemSubGroupDto>.CreateAsync(
                dtoQuery, request.PageNumber, request.PageSize);
        }
    }
} 