using MediatR;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.DeleteItemGroup;

public class DeleteItemGroupCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteItemGroupCommand(int id)
    {
        Id = id;
    }
} 