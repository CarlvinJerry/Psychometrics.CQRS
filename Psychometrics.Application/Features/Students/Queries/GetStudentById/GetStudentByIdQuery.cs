using System;
using MediatR;
using Psychometrics.Application.Features.Students.Queries.GetAllStudents;

namespace Psychometrics.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public Guid StudentId { get; set; }
    }
} 