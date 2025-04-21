using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.Students.Queries.GetStudentById;

public class GetStudentByIdQuery : IRequest<StudentDto?>
{
    public int Id { get; set; }

    public GetStudentByIdQuery(int id)
    {
        Id = id;
    }
} 