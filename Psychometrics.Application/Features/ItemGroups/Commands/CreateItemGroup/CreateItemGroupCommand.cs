using System;
using MediatR;

namespace Psychometrics.Application.Features.ItemGroups.Commands.CreateItemGroup
{
    public class CreateItemGroupCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
} 