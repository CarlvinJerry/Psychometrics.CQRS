using System.Collections.Generic;
using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.Responses.Queries.GetResponses;

public class GetResponsesQuery : IRequest<List<ResponseDto>>
{
} 