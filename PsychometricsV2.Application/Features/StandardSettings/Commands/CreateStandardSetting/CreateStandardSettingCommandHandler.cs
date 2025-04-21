using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.CreateStandardSetting;

public class CreateStandardSettingCommandHandler : IRequestHandler<CreateStandardSettingCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateStandardSettingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStandardSettingCommand request, CancellationToken cancellationToken)
    {
        var standardSetting = new StandardSetting
        {
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            CreatedDate = DateTime.UtcNow
        };

        _context.StandardSettings.Add(standardSetting);
        await _context.SaveChangesAsync(cancellationToken);

        return standardSetting.Id;
    }
} 