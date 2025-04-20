using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemResponses.Commands.DeleteItemResponse
{
    public class DeleteItemResponseCommandHandler : IRequestHandler<DeleteItemResponseCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteItemResponseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteItemResponseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemResponses.FindAsync(request.ItemResponseID);

            if (entity == null)
            {
                return false;
            }

            _context.ItemResponses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 