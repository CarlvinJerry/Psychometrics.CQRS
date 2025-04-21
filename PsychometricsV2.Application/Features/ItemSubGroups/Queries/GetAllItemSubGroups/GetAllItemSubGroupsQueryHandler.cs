using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;

public class GetAllItemSubGroupsQueryHandler : IRequestHandler<GetAllItemSubGroupsQuery, IEnumerable<ItemSubGroup>>
{
    private readonly IApplicationDbContext _context;

    public GetAllItemSubGroupsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemSubGroup>> Handle(GetAllItemSubGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _context.ItemSubGroups
            .Include(isg => isg.ItemGroup)
            .Include(isg => isg.ItemSubGroupType)
            .ToListAsync(cancellationToken);
    }
} 