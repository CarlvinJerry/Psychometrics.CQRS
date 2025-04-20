using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.DeleteItemSubGroup
{
    /// <summary>
    /// Command to delete an existing ItemSubGroup.
    /// </summary>
    public class DeleteItemSubGroupCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ItemSubGroup to delete.
        /// </summary>
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Handler for processing DeleteItemSubGroupCommand requests.
    /// </summary>
    public class DeleteItemSubGroupCommandHandler : IRequestHandler<DeleteItemSubGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteItemSubGroupCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public DeleteItemSubGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the deletion of an existing ItemSubGroup.
        /// </summary>
        /// <param name="request">The command containing the ID of the ItemSubGroup to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        /// <exception cref="NotFoundException">Thrown when the ItemSubGroup is not found.</exception>
        public async Task<Unit> Handle(DeleteItemSubGroupCommand request, CancellationToken cancellationToken)
        {
            var itemSubGroup = await _context.ItemSubGroups
                .FirstOrDefaultAsync(isg => isg.Id == request.Id, cancellationToken);

            if (itemSubGroup == null)
            {
                throw new NotFoundException(nameof(itemSubGroup), request.Id);
            }

            _context.ItemSubGroups.Remove(itemSubGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 