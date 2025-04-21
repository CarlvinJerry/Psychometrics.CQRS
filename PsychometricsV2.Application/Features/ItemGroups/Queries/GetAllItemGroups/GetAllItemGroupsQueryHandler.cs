using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetAllItemGroups;

public class GetAllItemGroupsQueryHandler : IRequestHandler<GetAllItemGroupsQuery, IEnumerable<ItemGroup>>
{
    private readonly IApplicationDbContext _context;

    public GetAllItemGroupsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemGroup>> Handle(GetAllItemGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _context.ItemGroups.ToListAsync(cancellationToken);
    }
} 