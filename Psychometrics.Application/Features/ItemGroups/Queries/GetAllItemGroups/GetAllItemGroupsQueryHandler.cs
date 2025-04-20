using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetAllItemGroups
{
    public class GetAllItemGroupsQueryHandler : IRequestHandler<GetAllItemGroupsQuery, PaginatedList<ItemGroupDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllItemGroupsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<ItemGroupDto>> Handle(GetAllItemGroupsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.ItemGroups
                .Include(ig => ig.Items)
                .Include(ig => ig.ItemSubGroups)
                .AsQueryable();

            // Apply search filter if provided
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(ig =>
                    ig.Name.ToLower().Contains(searchTerm) ||
                    ig.Description.ToLower().Contains(searchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                query = request.SortBy.ToLower() switch
                {
                    "name" => request.SortDescending ? 
                        query.OrderByDescending(ig => ig.Name) : 
                        query.OrderBy(ig => ig.Name),
                    "description" => request.SortDescending ? 
                        query.OrderByDescending(ig => ig.Description) : 
                        query.OrderBy(ig => ig.Description),
                    "createdat" => request.SortDescending ? 
                        query.OrderByDescending(ig => ig.CreatedAt) : 
                        query.OrderBy(ig => ig.CreatedAt),
                    _ => query.OrderByDescending(ig => ig.CreatedAt)
                };
            }
            else
            {
                // Default sorting by creation date
                query = query.OrderByDescending(ig => ig.CreatedAt);
            }

            // Project to DTO
            var dtoQuery = query.Select(ig => new ItemGroupDto
            {
                Id = ig.Id,
                Name = ig.Name,
                Description = ig.Description,
                CreatedAt = ig.CreatedAt,
                UpdatedAt = ig.UpdatedAt,
                ItemCount = ig.Items.Count,
                SubGroupCount = ig.ItemSubGroups.Count
            });

            // Apply pagination
            return await PaginatedList<ItemGroupDto>.CreateAsync(
                dtoQuery, request.PageNumber, request.PageSize);
        }
    }
} 