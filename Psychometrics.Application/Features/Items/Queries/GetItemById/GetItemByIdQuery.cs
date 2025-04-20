using System;
using MediatR;
using Psychometrics.Application.Features.Items.Queries.GetItemById;

namespace Psychometrics.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<ItemDto>
    {
        public Guid ItemId { get; set; }
    }
} 