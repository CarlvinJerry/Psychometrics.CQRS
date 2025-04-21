using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById;

public class GetItemSubGroupByIdQueryHandler : IRequestHandler<GetItemSubGroupByIdQuery, ItemSubGroup?>
{
    private readonly IApplicationDbContext _context;

    public GetItemSubGroupByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ItemSubGroup?> Handle(GetItemSubGroupByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.ItemSubGroups
            .Include(isg => isg.ItemGroup)
            .Include(isg => isg.ItemSubGroupType)
            .FirstOrDefaultAsync(isg => isg.Id == request.Id, cancellationToken);
    }
} 