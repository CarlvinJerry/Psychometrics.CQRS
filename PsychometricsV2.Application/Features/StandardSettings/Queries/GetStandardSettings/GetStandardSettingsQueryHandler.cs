using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.StandardSettings.Queries.GetStandardSettings;

public class GetStandardSettingsQueryHandler : IRequestHandler<GetStandardSettingsQuery, List<StandardSettingDto>>
{
    private readonly IApplicationDbContext _context;

    public GetStandardSettingsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StandardSettingDto>> Handle(GetStandardSettingsQuery request, CancellationToken cancellationToken)
    {
        return await _context.StandardSettings
            .Select(s => new StandardSettingDto
            {
                Id = s.Id,
                Method = s.Method,
                RecordMonth = s.RecordMonth,
                CalendarYear = s.CalendarYear,
                AcademicYear = s.AcademicYear,
                Category = s.Category,
                Type = s.Type,
                TeachingPeriod = s.TeachingPeriod,
                YearLevel = s.YearLevel,
                Phase = s.Phase,
                PassingScore = s.PassingScore,
                EXCScore = s.EXCScore,
                MaxScoreRaw = s.MaxScoreRaw,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            })
            .ToListAsync(cancellationToken);
    }
} 