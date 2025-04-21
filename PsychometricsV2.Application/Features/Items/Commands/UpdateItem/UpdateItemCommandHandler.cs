using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Common.Exceptions;
using PsychometricsV2.Application.Common.Interfaces;

namespace PsychometricsV2.Application.Features.Items.Commands.UpdateItem;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _context.Items
            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Item), request.Id);
        }

        var itemSubGroup = await _context.ItemSubGroups
            .FirstOrDefaultAsync(isg => isg.Id == request.ItemSubGroupId, cancellationToken);

        if (itemSubGroup == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.ItemSubGroup), request.ItemSubGroupId);
        }

        item.Code = request.Code;
        item.Name = request.Name;
        item.Description = request.Description;
        item.ItemSubGroupId = request.ItemSubGroupId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
} 