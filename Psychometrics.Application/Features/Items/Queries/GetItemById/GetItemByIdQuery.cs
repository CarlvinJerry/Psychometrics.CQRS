using MediatR;
using System;

namespace Psychometrics.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<ItemDto>
    {
        public Guid Id { get; set; }
    }
} 