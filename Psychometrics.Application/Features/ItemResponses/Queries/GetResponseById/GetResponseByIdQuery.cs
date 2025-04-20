using System;
using MediatR;

namespace Psychometrics.Application.Features.Responses.Queries.GetResponseById
{
    public class GetResponseByIdQuery : IRequest<ResponseDto>
    {
        public Guid Id { get; set; }
    }
} 