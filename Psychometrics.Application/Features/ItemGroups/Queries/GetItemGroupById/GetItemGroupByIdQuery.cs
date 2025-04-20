using System;
using MediatR;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetItemGroupById
{
    public record GetItemGroupByIdQuery(Guid Id) : IRequest<ItemGroupDto>;
} 