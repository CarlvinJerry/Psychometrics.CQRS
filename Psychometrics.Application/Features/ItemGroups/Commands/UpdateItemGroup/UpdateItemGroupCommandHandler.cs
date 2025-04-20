using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Commands.UpdateItemGroup
{
    /// <summary>
    /// Handler for processing UpdateItemGroupCommand requests.
    /// </summary>
    public class UpdateItemGroupCommandHandler : IRequestHandler<UpdateItemGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateItemGroupCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UpdateItemGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the update of an existing ItemGroup.
        /// </summary>
        /// <param name="request">The command containing the updated ItemGroup details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        public async Task<Unit> Handle(UpdateItemGroupCommand request, CancellationToken cancellationToken)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(request.Id);
            if (itemGroup == null)
            {
                throw new NotFoundException(nameof(itemGroup), request.Id);
            }

            itemGroup.Name = request.Name;
            itemGroup.Description = request.Description;
            itemGroup.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 