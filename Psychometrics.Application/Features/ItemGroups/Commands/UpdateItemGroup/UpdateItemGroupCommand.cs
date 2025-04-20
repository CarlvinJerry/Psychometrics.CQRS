using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemGroups.Commands.UpdateItemGroup
{
    public class UpdateItemGroupCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
} 