using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
                .FirstOrDefaultAsync(ig => ig.Code == request.ItemGroupCode, cancellationToken);
            if (itemGroup == null)
            {
                throw new NotFoundException(nameof(ItemGroup), request.ItemGroupCode);
            }

            var itemSubGroup = new ItemSubGroup
            {
                ItemSubGroupID = Guid.NewGuid(),
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                ItemGroupCode = request.ItemGroupCode,
                ItemSubGroupTypeCode = request.ItemSubGroupTypeCode,
                CreatedAt = DateTime.UtcNow
            };

            _context.ItemSubGroups.Add(itemSubGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return itemSubGroup.ItemSubGroupID;
        }
    }
} 