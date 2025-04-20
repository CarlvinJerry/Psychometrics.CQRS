using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.DeleteItemSubGroupType
{
    public class DeleteItemSubGroupTypeCommandHandler : IRequestHandler<DeleteItemSubGroupTypeCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteItemSubGroupTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

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