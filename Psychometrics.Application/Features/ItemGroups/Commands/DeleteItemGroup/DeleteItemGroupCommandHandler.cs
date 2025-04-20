using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Common.Exceptions;

namespace Psychometrics.Application.Features.ItemGroups.Commands.DeleteItemGroup
{
    /// <summary>
    /// Handler for deleting an ItemGroup
    /// </summary>
    public class DeleteItemGroupCommandHandler : IRequestHandler<DeleteItemGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteItemGroupCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public DeleteItemGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the request to delete an ItemGroup
        /// </summary>
        /// <param name="request">The command request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>True if the ItemGroup was deleted, false otherwise</returns>
        public async Task<bool> Handle(DeleteItemGroupCommand request, CancellationToken cancellationToken)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(new object[] { request.ItemGroupID }, cancellationToken);
            
            if (itemGroup == null)
            {
                throw new NotFoundException(nameof(ItemGroup), request.ItemGroupID);
            }

            _context.ItemGroups.Remove(itemGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 