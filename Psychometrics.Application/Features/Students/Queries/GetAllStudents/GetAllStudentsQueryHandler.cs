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
                    s.LastName.ToLower().Contains(searchTerm) ||
                    s.Email.ToLower().Contains(searchTerm) ||
                    s.StudentNumber.ToLower().Contains(searchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                query = request.SortBy.ToLower() switch
                {
                    "firstname" => request.SortDescending ? 
                        query.OrderByDescending(s => s.FirstName) : 
                        query.OrderBy(s => s.FirstName),
                    "lastname" => request.SortDescending ? 
                        query.OrderByDescending(s => s.LastName) : 
                        query.OrderBy(s => s.LastName),
                    "email" => request.SortDescending ? 
                        query.OrderByDescending(s => s.Email) : 
                        query.OrderBy(s => s.Email),
                    "studentnumber" => request.SortDescending ? 
                        query.OrderByDescending(s => s.StudentNumber) : 
                        query.OrderBy(s => s.StudentNumber),
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
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                StudentNumber = s.StudentNumber,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            });

            // Apply pagination
            return await PaginatedList<StudentDto>.CreateAsync(
                dtoQuery, request.PageNumber, request.PageSize);
        }
    }
} 