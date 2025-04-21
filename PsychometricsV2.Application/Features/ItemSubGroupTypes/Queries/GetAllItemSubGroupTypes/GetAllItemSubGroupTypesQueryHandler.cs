using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroupTypes.Queries.GetAllItemSubGroupTypes;

public class GetAllItemSubGroupTypesQueryHandler : IRequestHandler<GetAllItemSubGroupTypesQuery, IEnumerable<ItemSubGroupType>>
{
    private readonly IApplicationDbContext _context;

    public GetAllItemSubGroupTypesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemSubGroupType>> Handle(GetAllItemSubGroupTypesQuery request, CancellationToken cancellationToken)
    {
        return await _context.ItemSubGroupTypes.ToListAsync(cancellationToken);
    }
} 