using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Commands.CreateItemGroup
{
    public class CreateItemGroupCommandHandler : IRequestHandler<CreateItemGroupCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateItemGroupCommand request, CancellationToken cancellationToken)
        {
            var itemGroup = new ItemGroup
            {
                ItemGroupID = Guid.NewGuid(),
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.ItemGroups.Add(itemGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return itemGroup.ItemGroupID;
        }
    }
} 