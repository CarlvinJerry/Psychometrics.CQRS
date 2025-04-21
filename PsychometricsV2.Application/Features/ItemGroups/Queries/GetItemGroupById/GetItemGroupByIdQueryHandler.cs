using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroupById;

public class GetItemGroupByIdQueryHandler : IRequestHandler<GetItemGroupByIdQuery, ItemGroup?>
{
    private readonly IApplicationDbContext _context;

    public GetItemGroupByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ItemGroup?> Handle(GetItemGroupByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.ItemGroups
            .FirstOrDefaultAsync(ig => ig.Id == request.Id, cancellationToken);
    }
} 