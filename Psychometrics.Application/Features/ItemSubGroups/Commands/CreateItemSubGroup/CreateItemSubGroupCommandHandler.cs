using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup
{
    public class CreateItemSubGroupCommandHandler : IRequestHandler<CreateItemSubGroupCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemSubGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateItemSubGroupCommand request, CancellationToken cancellationToken)
        {
            // Verify that the ItemGroup exists
            var itemGroup = await _context.ItemGroups
                .FirstOrDefaultAsync(ig => ig.Id == request.ItemGroupId, cancellationToken);

            if (itemGroup == null)
            {
                throw new NotFoundException(nameof(ItemGroup), request.ItemGroupId);
            }

            var entity = new ItemSubGroup
            {
                Name = request.Name,
                Description = request.Description,
                ItemGroupId = request.ItemGroupId,
                ItemGroup = itemGroup,
                CreatedAt = DateTime.UtcNow
            };

            _context.ItemSubGroups.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
} 