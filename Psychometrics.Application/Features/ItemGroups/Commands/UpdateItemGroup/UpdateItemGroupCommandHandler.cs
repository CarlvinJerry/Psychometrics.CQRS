using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Commands.UpdateItemGroup
{
    public class UpdateItemGroupCommandHandler : IRequestHandler<UpdateItemGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateItemGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateItemGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemGroups
                .FirstOrDefaultAsync(ig => ig.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 