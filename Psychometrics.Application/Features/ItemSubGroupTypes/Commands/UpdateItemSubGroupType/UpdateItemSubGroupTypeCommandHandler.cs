using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.UpdateItemSubGroupType
{
    /// <summary>
    /// Handler for the UpdateItemSubGroupTypeCommand
    /// </summary>
    public class UpdateItemSubGroupTypeCommandHandler : IRequestHandler<UpdateItemSubGroupTypeCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateItemSubGroupTypeCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public UpdateItemSubGroupTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the UpdateItemSubGroupTypeCommand request
        /// </summary>
        /// <param name="request">The update command containing the ItemSubGroupType data</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A boolean indicating whether the update was successful</returns>
        public async Task<bool> Handle(UpdateItemSubGroupTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemSubGroupTypes.FindAsync(request.ItemSubGroupTypeID);

            if (entity == null)
            {
                return false;
            }

            entity.Code = request.Code;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 