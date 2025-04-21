using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.DeleteItemSubGroup;

/// <summary>
/// Handler for deleting an ItemSubGroup
/// </summary>
public class DeleteItemSubGroupCommandHandler : IRequestHandler<DeleteItemSubGroupCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the DeleteItemSubGroupCommandHandler class
    /// </summary>
    /// <param name="context">The application database context</param>
    public DeleteItemSubGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the request to delete an ItemSubGroup
    /// </summary>
    /// <param name="request">The command request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>True if the ItemSubGroup was deleted, false otherwise</returns>
    public async Task<bool> Handle(DeleteItemSubGroupCommand request, CancellationToken cancellationToken)
    {
        var itemSubGroup = await _context.ItemSubGroups
            .FirstOrDefaultAsync(x => x.ItemSubGroupID == request.ItemSubGroupID, cancellationToken);

        if (itemSubGroup == null)
        {
            throw new NotFoundException(nameof(ItemSubGroup), request.ItemSubGroupID);
        }

        _context.ItemSubGroups.Remove(itemSubGroup);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 