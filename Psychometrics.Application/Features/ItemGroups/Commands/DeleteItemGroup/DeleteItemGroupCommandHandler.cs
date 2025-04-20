using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Commands.DeleteItemGroup
{
    /// <summary>
    /// Handler for processing DeleteItemGroupCommand requests.
    /// </summary>
    public class DeleteItemGroupCommandHandler : IRequestHandler<DeleteItemGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteItemGroupCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public DeleteItemGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the deletion of an existing ItemGroup.
        /// </summary>
        /// <param name="request">The command containing the ID of the ItemGroup to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        public async Task<Unit> Handle(DeleteItemGroupCommand request, CancellationToken cancellationToken)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(request.Id);
            if (itemGroup == null)
            {
                return Unit.Value;
            }

            _context.ItemGroups.Remove(itemGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 