using System;
using MediatR;
using Psychometrics.Application.Features.ItemResponses.Queries.GetItemResponseById;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetResponseById
{
    public class GetResponseByIdQuery : IRequest<ItemResponseDto>
    {
        public Guid ItemResponseID { get; set; }
    }
} 