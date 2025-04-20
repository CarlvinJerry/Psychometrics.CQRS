using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Items.Commands.DeleteItem
{
    /// <summary>
    /// Handler for processing DeleteItemCommand requests.
    /// </summary>
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteItemCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public DeleteItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the deletion of an existing Item.
        /// </summary>
        /// <param name="request">The command containing the ID of the Item to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.Id);
            if (item == null)
            {
                return Unit.Value;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 