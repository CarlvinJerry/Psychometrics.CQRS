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
                Name = s.Name,
                Code = s.Code,
                Description = s.Description,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate
            })
            .ToListAsync(cancellationToken);
    }
} 