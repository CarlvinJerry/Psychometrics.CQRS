using System.Collections.Generic;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Items.Queries.GetAllItems;

public class GetAllItemsQuery : IRequest<IEnumerable<Item>>
{
} 