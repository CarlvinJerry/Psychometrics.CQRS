using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.UpdateStandardSetting;

public class UpdateStandardSettingCommandHandler : IRequestHandler<UpdateStandardSettingCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateStandardSettingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateStandardSettingCommand request, CancellationToken cancellationToken)
    {
        var standardSetting = await _context.StandardSettings.FindAsync(new object[] { request.Id }, cancellationToken);

        if (standardSetting == null)
        {
            return false;
        }

        standardSetting.Name = request.Name;
        standardSetting.Code = request.Code;
        standardSetting.Description = request.Description;
        standardSetting.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 