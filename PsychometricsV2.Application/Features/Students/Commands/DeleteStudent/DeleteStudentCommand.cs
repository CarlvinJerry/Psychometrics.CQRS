using MediatR;

namespace PsychometricsV2.Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteStudentCommand(int id)
    {
        Id = id;
    }
} 