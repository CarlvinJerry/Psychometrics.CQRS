using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.Responses.Queries.GetResponses;

public class GetResponsesQueryHandler : IRequestHandler<GetResponsesQuery, List<ResponseDto>>
{
    private readonly IApplicationDbContext _context;

    public GetResponsesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ResponseDto>> Handle(GetResponsesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Responses
            .Include(r => r.Student)
            .Include(r => r.Item)
            .Select(r => new ResponseDto
            {
                Id = r.Id,
                ResponseValue = r.ResponseValue,
                StudentId = r.StudentId,
                ItemId = r.ItemId,
                CalendarYear = r.CalendarYear,
                TeachingPeriod = r.TeachingPeriod,
                MscaaId = r.MscaaId,
                Student = r.Student != null ? new StudentDto
                {
                    StudentId = r.Student.StudentId,
                    CandidateNumber = r.Student.CandidateNumber,
                    EmailAddress = r.Student.EmailAddress,
                    FirstName = r.Student.FirstName,
                    Surname = r.Student.Surname
                } : null,
                Item = r.Item != null ? new ItemDto
                {
                    Id = r.Item.Id,
                    Code = r.Item.Code,
                    Name = r.Item.Name,
                    Description = r.Item.Description
                } : null
            })
            .ToListAsync(cancellationToken);
    }
} 