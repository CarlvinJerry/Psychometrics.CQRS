using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.UpdateItemSubGroup
{
    /// <summary>
    /// Command to update an existing ItemSubGroup.
    /// </summary>
    public class UpdateItemSubGroupCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ItemSubGroup to update.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the updated name of the ItemSubGroup.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the updated description of the ItemSubGroup.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the updated ID of the parent ItemGroup.
        /// </summary>
        public int ItemGroupId { get; set; }
    }

    /// <summary>
    /// Handler for processing UpdateItemSubGroupCommand requests.
    /// </summary>
    public class UpdateItemSubGroupCommandHandler : IRequestHandler<UpdateItemSubGroupCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the UpdateItemSubGroupCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public UpdateItemSubGroupCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the update of an existing ItemSubGroup.
        /// </summary>
        /// <param name="request">The command containing the updated ItemSubGroup details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        public async Task<Unit> Handle(UpdateItemSubGroupCommand request, CancellationToken cancellationToken)
        {
            var itemSubGroup = await _context.ItemSubGroups.FindAsync(request.Id);
            if (itemSubGroup == null)
            {
                return Unit.Value;
            }

            itemSubGroup.Name = request.Name;
            itemSubGroup.Description = request.Description;
            itemSubGroup.ItemGroupId = request.ItemGroupId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 