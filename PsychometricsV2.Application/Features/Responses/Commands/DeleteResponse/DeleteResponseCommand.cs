using MediatR;

namespace PsychometricsV2.Application.Features.Responses.Commands.DeleteResponse;

public class DeleteResponseCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteResponseCommand(int id)
    {
        Id = id;
    }
} 