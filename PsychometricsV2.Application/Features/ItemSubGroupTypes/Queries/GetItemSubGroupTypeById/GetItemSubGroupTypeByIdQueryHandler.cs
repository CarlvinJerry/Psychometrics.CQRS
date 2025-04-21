using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById;

public class GetItemSubGroupTypeByIdQueryHandler : IRequestHandler<GetItemSubGroupTypeByIdQuery, ItemSubGroupType?>
{
    private readonly IApplicationDbContext _context;

    public GetItemSubGroupTypeByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ItemSubGroupType?> Handle(GetItemSubGroupTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.ItemSubGroupTypes
            .FirstOrDefaultAsync(isgt => isgt.Id == request.Id, cancellationToken);
    }
} 