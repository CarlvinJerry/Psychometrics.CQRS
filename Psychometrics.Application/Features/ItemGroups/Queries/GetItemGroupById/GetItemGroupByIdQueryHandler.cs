using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetItemGroupById
{
    public class GetItemGroupByIdQueryHandler : IRequestHandler<GetItemGroupByIdQuery, ItemGroupDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemGroupByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemGroupDto> Handle(GetItemGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(new object[] { request.ItemGroupID }, cancellationToken);
            
            if (itemGroup == null)
            {
                throw new NotFoundException(nameof(ItemGroup), request.ItemGroupID);
            }

            return _mapper.Map<ItemGroupDto>(itemGroup);
        }
    }
} 