using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Items.Commands.DeleteItem
{
    /// <summary>
    /// Handler for deleting an Item
    /// </summary>
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteItemCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public DeleteItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the request to delete an Item
        /// </summary>
        /// <param name="request">The command request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>True if the Item was deleted, false otherwise</returns>
        public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items
                .FirstOrDefaultAsync(x => x.ItemID == request.ItemID, cancellationToken);

            if (entity == null)
                return false;

            _context.Items.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 