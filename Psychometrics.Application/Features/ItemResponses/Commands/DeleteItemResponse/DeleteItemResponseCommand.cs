using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemResponses.Commands.DeleteItemResponse
{
    public class DeleteItemResponseCommand : IRequest<bool>
    {
        public Guid ItemResponseID { get; set; }
    }
} 