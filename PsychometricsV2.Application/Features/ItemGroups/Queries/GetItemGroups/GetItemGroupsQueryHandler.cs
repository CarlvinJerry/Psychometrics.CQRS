using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroups;

public class GetItemGroupsQueryHandler : IRequestHandler<GetItemGroupsQuery, List<ItemGroupDto>>
{
    private readonly IApplicationDbContext _context;

    public GetItemGroupsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ItemGroupDto>> Handle(GetItemGroupsQuery request, CancellationToken cancellationToken)
    {
        var itemGroups = await _context.ItemGroups
            .Select(ig => new ItemGroupDto
            {
                Id = ig.Id,
                Name = ig.Name,
                Code = ig.Code,
                Description = ig.Description
            })
            .ToListAsync(cancellationToken);

        return itemGroups;
    }
} 