using MediatR;
using System;
using Psychometrics.Application.Features.Items.Queries.GetAllItems;

namespace Psychometrics.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<ItemDto>
    {
        public Guid ItemID { get; set; }
    }
} 