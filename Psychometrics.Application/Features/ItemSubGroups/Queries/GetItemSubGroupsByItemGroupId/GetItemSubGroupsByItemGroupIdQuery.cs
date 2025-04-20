using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroupsByItemGroupId
{
    public class GetItemSubGroupsByItemGroupIdQuery : IRequest<List<ItemSubGroupDto>>
    {
        public int ItemGroupId { get; set; }
    }

    public class GetItemSubGroupsByItemGroupIdQueryHandler : IRequestHandler<GetItemSubGroupsByItemGroupIdQuery, List<ItemSubGroupDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemSubGroupsByItemGroupIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ItemSubGroupDto>> Handle(GetItemSubGroupsByItemGroupIdQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroups = await _context.ItemSubGroups
                .Include(isg => isg.ItemGroup)
                .Where(isg => isg.ItemGroupId == request.ItemGroupId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<ItemSubGroupDto>>(itemSubGroups);
        }
    }
} 