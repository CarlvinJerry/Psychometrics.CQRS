using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemDto>
    {
        private readonly IApplicationDbContext _context;

        public GetItemByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            return new ItemDto
            {
                Id = entity.Id,
                Text = entity.Text,
                Description = entity.Description,
                ItemGroupId = entity.ItemGroupId,
                ItemSubGroupId = entity.ItemSubGroupId,
                Order = entity.Order,
                IsActive = entity.IsActive,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
} 