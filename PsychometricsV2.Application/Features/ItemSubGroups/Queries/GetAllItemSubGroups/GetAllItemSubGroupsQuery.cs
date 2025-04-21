using System.Collections.Generic;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups;

public class GetAllItemSubGroupsQuery : IRequest<IEnumerable<ItemSubGroup>>
{
} 