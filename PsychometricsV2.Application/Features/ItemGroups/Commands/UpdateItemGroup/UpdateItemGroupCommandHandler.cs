using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.UpdateItemGroup;

public class UpdateItemGroupCommandHandler : IRequestHandler<UpdateItemGroupCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateItemGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateItemGroupCommand request, CancellationToken cancellationToken)
    {
        var itemGroup = await _context.ItemGroups.FindAsync(new object[] { request.Id }, cancellationToken);

        if (itemGroup == null)
        {
            return false;
        }

        // Check if the new code already exists for a different item group
        if (request.Code != itemGroup.Code)
        {
            var existingItemGroup = await _context.ItemGroups
                .FirstOrDefaultAsync(ig => ig.Code == request.Code && ig.Id != request.Id, cancellationToken);

            if (existingItemGroup != null)
            {
                throw new Exception($"ItemGroup with code {request.Code} already exists.");
            }
        }

        itemGroup.Name = request.Name;
        itemGroup.Code = request.Code;
        itemGroup.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 