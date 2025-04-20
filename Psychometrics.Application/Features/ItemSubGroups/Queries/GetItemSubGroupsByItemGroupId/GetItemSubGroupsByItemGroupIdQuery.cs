using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroupsByItemGroupId
{
    /// <summary>
    /// Query to retrieve all ItemSubGroups for a specific ItemGroup.
    /// </summary>
    public class GetItemSubGroupsByItemGroupIdQuery : IRequest<List<ItemSubGroupDto>>
    {
        /// <summary>
        /// Gets or sets the code of the ItemGroup to filter by.
        /// </summary>
        public string ItemGroupCode { get; set; } = string.Empty;
    }

    /// <summary>
    /// Handler for processing GetItemSubGroupsByItemGroupIdQuery requests.
    /// </summary>
    public class GetItemSubGroupsByItemGroupIdQueryHandler : IRequestHandler<GetItemSubGroupsByItemGroupIdQuery, List<ItemSubGroupDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the GetItemSubGroupsByItemGroupIdQueryHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GetItemSubGroupsByItemGroupIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the retrieval of ItemSubGroups for a specific ItemGroup.
        /// </summary>
        /// <param name="request">The query containing the ItemGroup code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of ItemSubGroupDto objects.</returns>
        public async Task<List<ItemSubGroupDto>> Handle(GetItemSubGroupsByItemGroupIdQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroups = await _context.ItemSubGroups
                .Include(isg => isg.ItemGroup)
                .Include(isg => isg.ItemSubGroupType)
                .Where(isg => isg.ItemGroupCode == request.ItemGroupCode)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<ItemSubGroupDto>>(itemSubGroups);
        }
    }
} 