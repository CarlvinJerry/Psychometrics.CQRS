using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup;

public class CreateItemSubGroupCommandHandler : IRequestHandler<CreateItemSubGroupCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateItemSubGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateItemSubGroupCommand request, CancellationToken cancellationToken)
    {
        // Find the ItemGroup by code
        var itemGroup = await _context.ItemGroups
            .FirstOrDefaultAsync(ig => ig.Code == request.ItemGroupCode, cancellationToken);

        if (itemGroup == null)
        {
            throw new Exception($"ItemGroup with code {request.ItemGroupCode} not found.");
        }

        // Find the ItemSubGroupType by code
        var itemSubGroupType = await _context.ItemSubGroupTypes
            .FirstOrDefaultAsync(isgt => isgt.Code == request.ItemSubGroupTypeCode, cancellationToken);

        if (itemSubGroupType == null)
        {
            throw new Exception($"ItemSubGroupType with code {request.ItemSubGroupTypeCode} not found.");
        }

        // Check if an item sub group with the same code already exists
        var existingItemSubGroup = await _context.ItemSubGroups
            .FirstOrDefaultAsync(isg => isg.Code == request.Code, cancellationToken);

        if (existingItemSubGroup != null)
        {
            throw new Exception($"ItemSubGroup with code {request.Code} already exists.");
        }

        var itemSubGroup = new ItemSubGroup
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            ItemGroupId = itemGroup.Id,
            ItemSubGroupTypeId = itemSubGroupType.Id,
            CreatedAt = DateTime.UtcNow
        };

        await _context.ItemSubGroups.AddAsync(itemSubGroup, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return itemSubGroup.Id;
    }
} 