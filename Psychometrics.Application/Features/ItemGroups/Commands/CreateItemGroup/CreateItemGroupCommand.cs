using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemGroups.Commands.CreateItemGroup
{
    public class CreateItemGroupCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
} 