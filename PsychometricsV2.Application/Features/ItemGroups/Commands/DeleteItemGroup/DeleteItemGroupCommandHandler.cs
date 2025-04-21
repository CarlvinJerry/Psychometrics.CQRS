using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Common.Exceptions;
using PsychometricsV2.Application.Common.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.DeleteItemGroup;

public class DeleteItemGroupCommandHandler : IRequestHandler<DeleteItemGroupCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteItemGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteItemGroupCommand request, CancellationToken cancellationToken)
    {
        var itemGroup = await _context.ItemGroups.FindAsync(request.Id);

        if (itemGroup == null)
        {
            throw new NotFoundException(nameof(ItemGroup), request.Id);
        }

        // Check if the item group is being used by any items through item sub groups
        var itemsUsingGroup = await _context.Items
            .AnyAsync(x => x.ItemSubGroup.ItemGroupId == request.Id, cancellationToken);

        if (itemsUsingGroup)
        {
            throw new Exception($"Cannot delete ItemGroup with ID {request.Id} because it is being used by one or more items.");
        }

        _context.ItemGroups.Remove(itemGroup);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
} 