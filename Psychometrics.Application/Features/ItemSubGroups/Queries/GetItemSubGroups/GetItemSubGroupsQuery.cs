using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroups
{
    public class GetItemSubGroupsQuery : IRequest<List<ItemSubGroupDto>>
    {
    }

    public class GetItemSubGroupsQueryHandler : IRequestHandler<GetItemSubGroupsQuery, List<ItemSubGroupDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemSubGroupsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ItemSubGroupDto>> Handle(GetItemSubGroupsQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroups = await _context.ItemSubGroups
                .Include(isg => isg.ItemGroup)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<ItemSubGroupDto>>(itemSubGroups);
        }
    }
} 