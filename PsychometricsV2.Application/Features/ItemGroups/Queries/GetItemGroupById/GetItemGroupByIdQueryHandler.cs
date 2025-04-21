using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroupById;

public class GetItemGroupByIdQueryHandler : IRequestHandler<GetItemGroupByIdQuery, ItemGroupDto?>
{
    private readonly IApplicationDbContext _context;

    public GetItemGroupByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ItemGroupDto?> Handle(GetItemGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var itemGroup = await _context.ItemGroups
            .Where(ig => ig.Id == request.Id)
            .Select(ig => new ItemGroupDto
            {
                Id = ig.Id,
                Name = ig.Name,
                Code = ig.Code,
                Description = ig.Description
            })
            .FirstOrDefaultAsync(cancellationToken);

        return itemGroup;
    }
} 