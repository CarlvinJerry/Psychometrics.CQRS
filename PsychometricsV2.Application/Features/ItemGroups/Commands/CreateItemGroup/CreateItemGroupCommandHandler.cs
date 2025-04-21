using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.CreateItemGroup;

public class CreateItemGroupCommandHandler : IRequestHandler<CreateItemGroupCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateItemGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateItemGroupCommand request, CancellationToken cancellationToken)
    {
        // Check if an item group with the same code already exists
        var existingItemGroup = await _context.ItemGroups
            .FirstOrDefaultAsync(ig => ig.Code == request.Code, cancellationToken);

        if (existingItemGroup != null)
        {
            throw new Exception($"ItemGroup with code {request.Code} already exists.");
        }

        var itemGroup = new ItemGroup
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _context.ItemGroups.AddAsync(itemGroup, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return itemGroup.Id;
    }
} 