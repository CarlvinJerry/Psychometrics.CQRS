using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.UpdateItemGroup;

public class UpdateItemGroupCommandHandler : IRequestHandler<UpdateItemGroupCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateItemGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateItemGroupCommand request, CancellationToken cancellationToken)
    {
        var itemGroup = await _context.ItemGroups
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (itemGroup == null)
        {
            throw new Exception($"ItemGroup with ID {request.Id} not found.");
        }

        // Check if the new code is already in use by another item group
        var existingItemGroup = await _context.ItemGroups
            .FirstOrDefaultAsync(x => x.Code == request.Code && x.Id != request.Id, cancellationToken);

        if (existingItemGroup != null)
        {
            throw new Exception($"ItemGroup with code {request.Code} already exists.");
        }

        itemGroup.Name = request.Name;
        itemGroup.Code = request.Code;
        itemGroup.Description = request.Description;
        itemGroup.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
} 