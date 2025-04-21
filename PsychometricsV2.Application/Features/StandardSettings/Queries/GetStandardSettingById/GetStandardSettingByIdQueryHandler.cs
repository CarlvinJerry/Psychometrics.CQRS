using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.StandardSettings.Queries.GetStandardSettingById;

public class GetStandardSettingByIdQueryHandler : IRequestHandler<GetStandardSettingByIdQuery, StandardSettingDto?>
{
    private readonly IApplicationDbContext _context;

    public GetStandardSettingByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StandardSettingDto?> Handle(GetStandardSettingByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.StandardSettings
            .Where(s => s.Id == request.Id)
            .Select(s => new StandardSettingDto
            {
                Id = s.Id,
                Name = s.Name,
                Code = s.Code,
                Description = s.Description,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
} 