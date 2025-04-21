using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.Responses.Queries.GetResponseById;

public class GetResponseByIdQuery : IRequest<ResponseDto?>
{
    public int Id { get; set; }

    public GetResponseByIdQuery(int id)
    {
        Id = id;
    }
} 