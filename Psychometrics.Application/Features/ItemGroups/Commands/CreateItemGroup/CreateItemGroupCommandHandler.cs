using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Psychometrics.Application.Interfaces;
using Psychometrics.Domain.Entities;

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
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.ItemGroups.Add(itemGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return itemGroup.Id;
        }
    }
} 