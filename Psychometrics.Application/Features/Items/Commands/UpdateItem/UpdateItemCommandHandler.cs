using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Items.Commands.UpdateItem
{
    /// <summary>
    /// Handler for processing UpdateItemCommand requests.
    /// </summary>
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateItemCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UpdateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the update of an existing Item.
        /// </summary>
        /// <param name="request">The command containing the updated Item details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.Id);
            if (item == null)
            {
                return Unit.Value;
            }

            item.Text = request.Text;
            item.Description = request.Description;
            item.ItemGroupId = request.ItemGroupId;
            item.ItemSubGroupId = request.ItemSubGroupId;
            item.Order = request.Order;
            item.IsActive = request.IsActive;
            item.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 