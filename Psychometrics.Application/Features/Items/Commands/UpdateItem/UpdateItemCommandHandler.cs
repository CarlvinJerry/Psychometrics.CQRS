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
    /// Handler for updating an Item
    /// </summary>
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateItemCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public UpdateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the request to update an Item
        /// </summary>
        /// <param name="request">The command request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>True if the Item was updated, false otherwise</returns>
        public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items
                .FirstOrDefaultAsync(x => x.ItemID == request.ItemID, cancellationToken);

            if (entity == null)
                return false;

            entity.Code = request.Code;
            entity.MSCAAID = request.MSCAAID;
            entity.ItemSubGroupCode = request.ItemSubGroupCode;
            entity.ItemGroupCode = request.ItemGroupCode;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 