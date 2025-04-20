using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById
{
    public class GetItemSubGroupByIdQueryHandler : IRequestHandler<GetItemSubGroupByIdQuery, ItemSubGroupDto>
    {
        private readonly IApplicationDbContext _context;

        public GetItemSubGroupByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemSubGroupDto> Handle(GetItemSubGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroup = await _context.ItemSubGroups
                .FirstOrDefaultAsync(isg => isg.ItemSubGroupID == request.ItemSubGroupId, cancellationToken);

            if (itemSubGroup == null)
            {
                return null;
            }

            return new ItemSubGroupDto
            {
                ItemSubGroupID = itemSubGroup.ItemSubGroupID,
                Name = itemSubGroup.Name,
                Description = itemSubGroup.Description,
                Code = itemSubGroup.Code,
                ItemGroupCode = itemSubGroup.ItemGroupCode,
                ItemSubGroupTypeCode = itemSubGroup.ItemSubGroupTypeCode
            };
        }
    }
} 