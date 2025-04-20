using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetAllItemSubGroupTypes
{
    /// <summary>
    /// Handler for retrieving all ItemSubGroupTypes
    /// </summary>
    public class GetAllItemSubGroupTypesQueryHandler : IRequestHandler<GetAllItemSubGroupTypesQuery, IEnumerable<ItemSubGroupTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the GetAllItemSubGroupTypesQueryHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetAllItemSubGroupTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the request to retrieve all ItemSubGroupTypes
        /// </summary>
        /// <param name="request">The query request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A collection of ItemSubGroupTypeDto objects</returns>
        public async Task<IEnumerable<ItemSubGroupTypeDto>> Handle(GetAllItemSubGroupTypesQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroupTypes = await _context.ItemSubGroupTypes
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ItemSubGroupTypeDto>>(itemSubGroupTypes);
        }
    }
} 