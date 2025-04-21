using System;
using MediatR;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.DeleteItemGroup;

public class DeleteItemGroupCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
} 