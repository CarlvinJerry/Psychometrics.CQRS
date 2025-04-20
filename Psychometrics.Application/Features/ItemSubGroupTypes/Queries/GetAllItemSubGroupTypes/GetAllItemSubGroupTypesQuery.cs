using System.Collections.Generic;
using MediatR;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetAllItemSubGroupTypes
{
    /// <summary>
    /// Query to retrieve all ItemSubGroupTypes
    /// </summary>
    public class GetAllItemSubGroupTypesQuery : IRequest<IEnumerable<ItemSubGroupTypeDto>>
    {
    }
} 