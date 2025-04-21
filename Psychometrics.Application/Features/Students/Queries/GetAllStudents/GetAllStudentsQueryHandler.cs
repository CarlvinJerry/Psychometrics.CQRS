using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, PaginatedList<StudentDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStudentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Students.AsQueryable();

            // Apply search filter if provided
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(s =>
                    s.FirstName.ToLower().Contains(searchTerm) ||
                    s.Surname.ToLower().Contains(searchTerm) ||
                    s.EmailAddress.ToLower().Contains(searchTerm) ||
                    s.CandidateNumber.ToLower().Contains(searchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                query = request.SortBy.ToLower() switch
                {
                    "firstname" => request.SortDescending ? 
                        query.OrderByDescending(s => s.FirstName) : 
                        query.OrderBy(s => s.FirstName),
                    "surname" => request.SortDescending ? 
                        query.OrderByDescending(s => s.Surname) : 
                        query.OrderBy(s => s.Surname),
                    "emailaddress" => request.SortDescending ? 
                        query.OrderByDescending(s => s.EmailAddress) : 
                        query.OrderBy(s => s.EmailAddress),
                    "candidatenumber" => request.SortDescending ? 
                        query.OrderByDescending(s => s.CandidateNumber) : 
                        query.OrderBy(s => s.CandidateNumber),
                    "createdat" => request.SortDescending ? 
                        query.OrderByDescending(s => s.CreatedAt) : 
                        query.OrderBy(s => s.CreatedAt),
                    _ => query.OrderByDescending(s => s.CreatedAt)
                };
            }
            else
            {
                // Default sorting by creation date
                query = query.OrderByDescending(s => s.CreatedAt);
            }

            // Project to DTO
            var dtoQuery = query.Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                CandidateNumber = s.CandidateNumber,
                EmailAddress = s.EmailAddress,
                FirstName = s.FirstName,
                Surname = s.Surname,
                Year = s.Year,
                YearOfEntry = s.YearOfEntry,
                SCJCode = s.SCJCode,
                AcademicYear = s.AcademicYear,
                Block = s.Block,
                ProgressCodeName = s.ProgressCodeName,
                Gender = s.Gender,
                AgeOnEntry = s.AgeOnEntry,
                Ethnicity = s.Ethnicity,
                Disability = s.Disability,
                HighestQualificationOnEntry = s.HighestQualificationOnEntry,
                RegionofDomicile = s.RegionofDomicile,
                Religion = s.Religion,
                SocioEconomicClass = s.SocioEconomicClass,
                PersonalTutor = s.PersonalTutor,
                ExternalTutorEmail = s.ExternalTutorEmail,
                HomeAddress = s.HomeAddress,
                LocalNonLocalWP = s.LocalNonLocalWP,
                DANU = s.DANU,
                Notes = s.Notes,
                IsActive = s.IsActive,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            });

            // Apply pagination
            return await PaginatedList<StudentDto>.CreateAsync(
                dtoQuery, request.PageNumber, request.PageSize);
        }
    }
} 