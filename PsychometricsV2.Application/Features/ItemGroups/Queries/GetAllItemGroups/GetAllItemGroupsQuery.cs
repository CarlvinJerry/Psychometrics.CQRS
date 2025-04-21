using System.Collections.Generic;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemGroups.Queries.GetAllItemGroups;

public class GetAllItemGroupsQuery : IRequest<IEnumerable<ItemGroup>>
{
} 