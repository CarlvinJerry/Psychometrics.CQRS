using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new Item
            {
                Text = request.Text,
                Description = request.Description,
                ItemGroupId = request.ItemGroupId,
                ItemSubGroupId = request.ItemSubGroupId,
                Order = request.Order,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            _context.Items.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
} 