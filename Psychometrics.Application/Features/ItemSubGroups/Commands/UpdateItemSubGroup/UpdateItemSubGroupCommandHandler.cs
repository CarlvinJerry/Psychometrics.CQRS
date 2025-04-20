using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.UpdateItemSubGroup;

/// <summary>
/// Handler for processing UpdateItemSubGroupCommand requests.
/// </summary>
public class UpdateItemSubGroupCommandHandler : IRequestHandler<UpdateItemSubGroupCommand, bool>
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
    /// <returns>True if the update was successful, false otherwise.</returns>
    public async Task<bool> Handle(UpdateItemSubGroupCommand request, CancellationToken cancellationToken)
    {
        var itemSubGroup = await _context.ItemSubGroups.FindAsync(new object[] { request.ItemSubGroupID }, cancellationToken);
        
        if (itemSubGroup == null)
        {
            throw new NotFoundException(nameof(ItemSubGroup), request.ItemSubGroupID);
        }

        itemSubGroup.Name = request.Name;
        itemSubGroup.Description = request.Description;
        itemSubGroup.Code = request.Code;
        itemSubGroup.ItemGroupCode = request.ItemGroupCode;
        itemSubGroup.ItemSubGroupTypeCode = request.ItemSubGroupTypeCode;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 