using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemGroups.Commands.DeleteItemGroup
{
    public class DeleteItemGroupCommand : IRequest
    {
        public Guid Id { get; set; }
    }
} 