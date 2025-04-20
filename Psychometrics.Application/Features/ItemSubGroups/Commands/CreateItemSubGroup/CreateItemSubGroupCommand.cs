using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup
{
    /// <summary>
    /// Command to create a new ItemSubGroup.
    /// </summary>
    public class CreateItemSubGroupCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the name of the ItemSubGroup.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ItemSubGroup.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the parent ItemGroup.
        /// </summary>
        public int ItemGroupId { get; set; }
    }

    /// <summary>
    /// Handler for processing CreateItemSubGroupCommand requests.
    /// </summary>
    public class CreateItemSubGroupCommandHandler : IRequestHandler<CreateItemSubGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the CreateItemSubGroupCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public CreateItemSubGroupCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the creation of a new ItemSubGroup.
        /// </summary>
        /// <param name="request">The command containing the ItemSubGroup details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The ID of the newly created ItemSubGroup.</returns>
        public async Task<int> Handle(CreateItemSubGroupCommand request, CancellationToken cancellationToken)
        {
            var itemSubGroup = new ItemSubGroup
            {
                Name = request.Name,
                Description = request.Description,
                ItemGroupId = request.ItemGroupId
            };

            _context.ItemSubGroups.Add(itemSubGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return itemSubGroup.Id;
        }
    }
} 