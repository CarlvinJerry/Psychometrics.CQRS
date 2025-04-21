using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.CreateStandardSetting;

public class CreateStandardSettingCommandHandler : IRequestHandler<CreateStandardSettingCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateStandardSettingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateStandardSettingCommand request, CancellationToken cancellationToken)
    {
        var standardSetting = new StandardSetting
        {
            Id = Guid.NewGuid(),
            Method = request.Method,
            RecordMonth = request.RecordMonth,
            CalendarYear = request.CalendarYear,
            AcademicYear = request.AcademicYear,
            Category = request.Category,
            Type = request.Type,
            TeachingPeriod = request.TeachingPeriod,
            YearLevel = request.YearLevel,
            Phase = request.Phase,
            PassingScore = request.PassingScore,
            EXCScore = request.EXCScore,
            MaxScoreRaw = request.MaxScoreRaw,
            CreatedAt = DateTime.UtcNow
        };

        _context.StandardSettings.Add(standardSetting);
        await _context.SaveChangesAsync(cancellationToken);

        return standardSetting.Id;
    }
} 