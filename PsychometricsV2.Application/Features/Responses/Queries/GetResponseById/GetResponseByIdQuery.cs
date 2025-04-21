using System;
using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.Responses.Queries.GetResponseById;

public class GetResponseByIdQuery : IRequest<ResponseDto?>
{
    public Guid Id { get; set; }

    public GetResponseByIdQuery(Guid id)
    {
        Id = id;
    }
} 