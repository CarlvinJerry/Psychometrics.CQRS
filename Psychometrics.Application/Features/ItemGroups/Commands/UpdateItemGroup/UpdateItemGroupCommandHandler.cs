using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Commands.UpdateItemGroup
{
    /// <summary>
    /// Handler for updating an ItemGroup
    /// </summary>
    public class UpdateItemGroupCommandHandler : IRequestHandler<UpdateItemGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateItemGroupCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public UpdateItemGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the request to update an ItemGroup
        /// </summary>
        /// <param name="request">The command request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>True if the ItemGroup was updated, false otherwise</returns>
        public async Task<bool> Handle(UpdateItemGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemGroups
                .FirstOrDefaultAsync(x => x.ItemGroupID == request.ItemGroupID, cancellationToken);

            if (entity == null)
                return false;

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Code = request.Code;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 