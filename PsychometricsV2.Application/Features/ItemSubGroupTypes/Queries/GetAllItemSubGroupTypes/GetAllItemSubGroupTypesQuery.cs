using System.Collections.Generic;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroupTypes.Queries.GetAllItemSubGroupTypes;

public class GetAllItemSubGroupTypesQuery : IRequest<IEnumerable<ItemSubGroupType>>
{
} 