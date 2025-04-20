using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.DeleteItemSubGroupType
{
    /// <summary>
    /// Handler for the DeleteItemSubGroupTypeCommand
    /// </summary>
    public class DeleteItemSubGroupTypeCommandHandler : IRequestHandler<DeleteItemSubGroupTypeCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteItemSubGroupTypeCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public DeleteItemSubGroupTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the DeleteItemSubGroupTypeCommand request
        /// </summary>
        /// <param name="request">The delete command containing the ItemSubGroupType ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A boolean indicating whether the deletion was successful</returns>
        public async Task<bool> Handle(DeleteItemSubGroupTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemSubGroupTypes.FindAsync(request.ItemSubGroupTypeID);

            if (entity == null)
            {
                return false;
            }

            _context.ItemSubGroupTypes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 