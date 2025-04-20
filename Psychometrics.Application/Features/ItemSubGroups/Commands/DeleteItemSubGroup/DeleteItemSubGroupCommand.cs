using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.DeleteItemSubGroup
{
    public class DeleteItemSubGroupCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteItemSubGroupCommandHandler : IRequestHandler<DeleteItemSubGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteItemSubGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

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