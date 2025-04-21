using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById
{
    public class GetItemSubGroupByIdQueryHandler : IRequestHandler<GetItemSubGroupByIdQuery, ItemSubGroupDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemSubGroupByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemSubGroupDto> Handle(GetItemSubGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroup = await _context.ItemSubGroups
                .Include(isg => isg.ItemGroup)
                .Include(isg => isg.ItemSubGroupType)
                .FirstOrDefaultAsync(isg => isg.ItemSubGroupID == request.ItemSubGroupID, cancellationToken);

            if (itemSubGroup == null)
            {
                throw new NotFoundException(nameof(ItemSubGroup), request.ItemSubGroupID);
            }

            return _mapper.Map<ItemSubGroupDto>(itemSubGroup);
        }
    }
} 