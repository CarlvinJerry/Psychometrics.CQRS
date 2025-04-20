using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemGroups.Commands.DeleteItemGroup
{
    public class DeleteItemGroupCommand : IRequest<bool>
    {
        public Guid ItemGroupID { get; set; }
    }
} 