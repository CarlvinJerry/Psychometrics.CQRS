using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetItemResponseById
{
    public class GetItemResponseByIdQuery : IRequest<ItemResponseDto>
    {
        public Guid Id { get; set; }
    }
} 