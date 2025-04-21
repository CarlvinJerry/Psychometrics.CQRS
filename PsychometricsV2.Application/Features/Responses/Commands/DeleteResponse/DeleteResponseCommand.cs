using MediatR;

namespace PsychometricsV2.Application.Features.Responses.Commands.DeleteResponse;

public class DeleteResponseCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteResponseCommand(Guid id)
    {
        Id = id;
    }
} 