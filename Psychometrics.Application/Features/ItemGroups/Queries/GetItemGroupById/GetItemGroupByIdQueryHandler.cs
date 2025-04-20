using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using System.Linq;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetItemGroupById
{
    public class GetItemGroupByIdQueryHandler : IRequestHandler<GetItemGroupByIdQuery, ItemGroupDto>
    {
        private readonly IApplicationDbContext _context;

        public GetItemGroupByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemGroupDto> Handle(GetItemGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var itemGroup = await _context.ItemGroups
                .Include(ig => ig.Items)
                .Include(ig => ig.ItemSubGroups)
                .FirstOrDefaultAsync(ig => ig.Id == request.Id, cancellationToken);

            if (itemGroup == null)
            {
                throw new Exception($"ItemGroup with ID {request.Id} not found.");
            }

            return new ItemGroupDto
            {
                Id = itemGroup.Id,
                Name = itemGroup.Name,
                Description = itemGroup.Description,
                CreatedAt = itemGroup.CreatedAt,
                UpdatedAt = itemGroup.UpdatedAt,
                Items = itemGroup.Items.Select(i => new ItemDto
                {
                    Id = i.Id,
                    ItemCode = i.ItemCode,
                    Question = i.Question
                }).ToList(),
                SubGroups = itemGroup.ItemSubGroups.Select(sg => new ItemSubGroupDto
                {
                    Id = sg.Id,
                    Name = sg.Name,
                    Description = sg.Description
                }).ToList()
            };
        }
    }
} 