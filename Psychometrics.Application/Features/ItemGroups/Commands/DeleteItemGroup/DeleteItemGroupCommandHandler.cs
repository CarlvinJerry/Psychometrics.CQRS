using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Commands.DeleteItemGroup
{
    public class DeleteItemGroupCommandHandler : IRequestHandler<DeleteItemGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteItemGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteItemGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemGroups
                .Include(ig => ig.Items)
                .Include(ig => ig.ItemSubGroups)
                .FirstOrDefaultAsync(ig => ig.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            // Remove associated items and subgroups
            _context.Items.RemoveRange(entity.Items);
            _context.ItemSubGroups.RemoveRange(entity.ItemSubGroups);
            _context.ItemGroups.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 