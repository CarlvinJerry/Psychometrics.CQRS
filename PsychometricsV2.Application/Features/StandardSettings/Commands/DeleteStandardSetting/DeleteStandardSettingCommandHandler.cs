using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.DeleteStandardSetting;

public class DeleteStandardSettingCommandHandler : IRequestHandler<DeleteStandardSettingCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteStandardSettingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteStandardSettingCommand request, CancellationToken cancellationToken)
    {
        var standardSetting = await _context.StandardSettings.FindAsync(new object[] { request.Id }, cancellationToken);

        if (standardSetting == null)
        {
            return false;
        }

        _context.StandardSettings.Remove(standardSetting);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 