using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.Students.Queries.GetStudents;

public class GetStudentsQuery : IRequest<List<StudentDto>>
{
} 