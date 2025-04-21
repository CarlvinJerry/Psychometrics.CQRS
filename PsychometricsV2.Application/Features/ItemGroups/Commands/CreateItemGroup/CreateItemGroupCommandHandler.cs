using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.CreateItemGroup;

public class CreateItemGroupCommandHandler : IRequestHandler<CreateItemGroupCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateItemGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateItemGroupCommand request, CancellationToken cancellationToken)
    {
        var itemGroup = new ItemGroup
        {
            Name = request.Name,
            Code = request.Code,
            Description = request.Description
        };

        _context.ItemGroups.Add(itemGroup);
        await _context.SaveChangesAsync(cancellationToken);

        return itemGroup.Id;
    }
} 