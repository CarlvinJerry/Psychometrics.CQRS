using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById
{
    /// <summary>
    /// Query to retrieve a specific ItemSubGroup by its ID.
    /// </summary>
    public class GetItemSubGroupByIdQuery : IRequest<ItemSubGroupDto>
    {
        /// <summary>
        /// Gets or sets the ID of the ItemSubGroup to retrieve.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Handler for processing GetItemSubGroupByIdQuery requests.
    /// </summary>
    public class GetItemSubGroupByIdQueryHandler : IRequestHandler<GetItemSubGroupByIdQuery, ItemSubGroupDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the GetItemSubGroupByIdQueryHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GetItemSubGroupByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the retrieval of a specific ItemSubGroup by its ID.
        /// </summary>
        /// <param name="request">The query containing the ItemSubGroup ID.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The ItemSubGroupDto object if found.</returns>
        /// <exception cref="NotFoundException">Thrown when the ItemSubGroup is not found.</exception>
        public async Task<ItemSubGroupDto> Handle(GetItemSubGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var itemSubGroup = await _context.ItemSubGroups
                .Include(isg => isg.ItemGroup)
                .FirstOrDefaultAsync(isg => isg.Id == request.Id, cancellationToken);

            if (itemSubGroup == null)
            {
                throw new NotFoundException(nameof(itemSubGroup), request.Id);
            }

            return _mapper.Map<ItemSubGroupDto>(itemSubGroup);
        }
    }
} 