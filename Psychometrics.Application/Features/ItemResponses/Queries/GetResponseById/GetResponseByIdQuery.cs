using System;
using MediatR;
using Psychometrics.Application.Features.ItemResponses.Queries.GetResponseById;

namespace Psychometrics.Application.Features.ItemResponses.Queries.GetResponseById
{
    public class GetResponseByIdQuery : IRequest<ResponseDto>
    {
        public Guid ItemResponseID { get; set; }
    }
} 