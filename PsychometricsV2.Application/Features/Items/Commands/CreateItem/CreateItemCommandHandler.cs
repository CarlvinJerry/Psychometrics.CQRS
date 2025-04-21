using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Items.Commands.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        // Find the ItemSubGroup by code
        var itemSubGroup = await _context.ItemSubGroups
            .FirstOrDefaultAsync(isg => isg.Code == request.ItemSubGroupCode, cancellationToken);

        if (itemSubGroup == null)
        {
            throw new Exception($"ItemSubGroup with code {request.ItemSubGroupCode} not found.");
        }

        // Check if an item with the same code already exists
        var existingItem = await _context.Items
            .FirstOrDefaultAsync(i => i.Code == request.Code, cancellationToken);

        if (existingItem != null)
        {
            throw new Exception($"Item with code {request.Code} already exists.");
        }

        var item = new Item
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            ItemSubGroupId = itemSubGroup.Id,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Items.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return item.Id;
    }
} 