using MediatR;
using System;
using System.Collections.Generic;

namespace Psychometrics.Application.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<PaginatedList<StudentDto>>
    {
        public string SearchTerm { get; set; }
        public string SortBy { get; set; }
        public bool SortDescending { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 