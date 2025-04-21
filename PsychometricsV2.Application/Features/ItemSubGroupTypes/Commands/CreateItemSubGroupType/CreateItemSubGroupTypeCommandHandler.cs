using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType;

public class CreateItemSubGroupTypeCommandHandler : IRequestHandler<CreateItemSubGroupTypeCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateItemSubGroupTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateItemSubGroupTypeCommand request, CancellationToken cancellationToken)
    {
        // Check if an item sub group type with the same code already exists
        var existingItemSubGroupType = await _context.ItemSubGroupTypes
            .FirstOrDefaultAsync(isgt => isgt.Code == request.Code, cancellationToken);

        if (existingItemSubGroupType != null)
        {
            throw new Exception($"ItemSubGroupType with code {request.Code} already exists.");
        }

        var itemSubGroupType = new ItemSubGroupType
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _context.ItemSubGroupTypes.AddAsync(itemSubGroupType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return itemSubGroupType.Id;
    }
} 