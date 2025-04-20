using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType
{
    /// <summary>
    /// Handler for the CreateItemSubGroupTypeCommand
    /// </summary>
    public class CreateItemSubGroupTypeCommandHandler : IRequestHandler<CreateItemSubGroupTypeCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the CreateItemSubGroupTypeCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public CreateItemSubGroupTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the CreateItemSubGroupTypeCommand request
        /// </summary>
        /// <param name="request">The create command containing the ItemSubGroupType data</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The unique identifier of the newly created ItemSubGroupType</returns>
        public async Task<Guid> Handle(CreateItemSubGroupTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new ItemSubGroupType
            {
                ItemSubGroupTypeID = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.ItemSubGroupTypes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.ItemSubGroupTypeID;
        }
    }
} 