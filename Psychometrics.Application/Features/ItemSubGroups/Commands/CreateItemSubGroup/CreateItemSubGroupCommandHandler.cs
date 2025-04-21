using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

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
            // Validate that ItemGroup exists
            var itemGroup = await _context.ItemGroups
                .FirstOrDefaultAsync(ig => ig.ItemGroupID == request.ItemGroupID, cancellationToken);
            if (itemGroup == null)
            {
                throw new NotFoundException(nameof(ItemGroup), request.ItemGroupID);
            }

            // Validate that ItemSubGroupType exists
            var itemSubGroupType = await _context.ItemSubGroupTypes
                .FirstOrDefaultAsync(ist => ist.ItemSubGroupTypeID == request.ItemSubGroupTypeID, cancellationToken);
            if (itemSubGroupType == null)
            {
                throw new NotFoundException(nameof(ItemSubGroupType), request.ItemSubGroupTypeID);
            }

            var itemSubGroup = new ItemSubGroup
            {
                ItemSubGroupID = Guid.NewGuid(),
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                ItemGroupID = request.ItemGroupID,
                ItemSubGroupTypeID = request.ItemSubGroupTypeID,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.ItemSubGroups.Add(itemSubGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return itemSubGroup.ItemSubGroupID;
        }
    }
} 