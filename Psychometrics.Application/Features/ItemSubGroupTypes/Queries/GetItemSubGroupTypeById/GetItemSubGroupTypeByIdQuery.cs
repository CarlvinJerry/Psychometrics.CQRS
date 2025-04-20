using System;
using MediatR;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById
{
    public record GetItemSubGroupTypeByIdQuery(Guid Id) : IRequest<ItemSubGroupTypeDto>;
} 