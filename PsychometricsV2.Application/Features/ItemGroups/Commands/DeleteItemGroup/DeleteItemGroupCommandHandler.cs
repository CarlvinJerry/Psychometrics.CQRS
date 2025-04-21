using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.DeleteItemGroup;

public class DeleteItemGroupCommandHandler : IRequestHandler<DeleteItemGroupCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteItemGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteItemGroupCommand request, CancellationToken cancellationToken)
    {
        var itemGroup = await _context.ItemGroups.FindAsync(new object[] { request.Id }, cancellationToken);

        if (itemGroup == null)
        {
            return false;
        }

        _context.ItemGroups.Remove(itemGroup);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 