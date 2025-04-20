using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById
{
    public class GetItemSubGroupTypeByIdQueryHandler : IRequestHandler<GetItemSubGroupTypeByIdQuery, ItemSubGroupTypeDto>
    {
        private readonly IApplicationDbContext _context;

        public GetItemSubGroupTypeByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemSubGroupTypeDto> Handle(GetItemSubGroupTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroupType = await _context.ItemSubGroupTypes
                .FirstOrDefaultAsync(ist => ist.ItemSubGroupTypeID == request.Id, cancellationToken);

            if (itemSubGroupType == null)
            {
                throw new Exception($"ItemSubGroupType with ID {request.Id} not found.");
            }

            return new ItemSubGroupTypeDto
            {
                ItemSubGroupTypeID = itemSubGroupType.ItemSubGroupTypeID,
                Code = itemSubGroupType.Code,
                Name = itemSubGroupType.Name,
                Description = itemSubGroupType.Description
            };
        }
    }
} 