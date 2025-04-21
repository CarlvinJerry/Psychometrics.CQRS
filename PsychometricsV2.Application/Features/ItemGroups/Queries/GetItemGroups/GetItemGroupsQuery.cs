using MediatR;
using PsychometricsV2.Application.DTOs;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetItemGroups;

public class GetItemGroupsQuery : IRequest<List<ItemGroupDto>>
{
} 