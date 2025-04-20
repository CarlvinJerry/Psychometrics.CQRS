using System;
using MediatR;
using Psychometrics.Application.Features.ItemGroups.Queries.GetAllItemGroups;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetItemGroupById
{
    public class GetItemGroupByIdQuery : IRequest<ItemGroupDto>
    {
        public Guid ItemGroupID { get; set; }
    }
} 