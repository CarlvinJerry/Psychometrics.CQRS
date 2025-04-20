using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById
{
    /// <summary>
    /// Query to retrieve an ItemSubGroupType by its ID
    /// </summary>
    public class GetItemSubGroupTypeByIdQuery : IRequest<ItemSubGroupTypeDto>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ItemSubGroupType
        /// </summary>
        public Guid ItemSubGroupTypeID { get; set; }
    }

    /// <summary>
    /// Handler for retrieving an ItemSubGroupType by its ID
    /// </summary>
    public class GetItemSubGroupTypeByIdQueryHandler : IRequestHandler<GetItemSubGroupTypeByIdQuery, ItemSubGroupTypeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the GetItemSubGroupTypeByIdQueryHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetItemSubGroupTypeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetItemSubGroupTypeByIdQuery request
        /// </summary>
        /// <param name="request">The query request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The ItemSubGroupTypeDto if found, null otherwise</returns>
        public async Task<ItemSubGroupTypeDto> Handle(GetItemSubGroupTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroupType = await _context.ItemSubGroupTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ItemSubGroupTypeID == request.ItemSubGroupTypeID, cancellationToken);

            return _mapper.Map<ItemSubGroupTypeDto>(itemSubGroupType);
        }
    }
} 