using MediatR;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemGroups.Queries.GetAllItemGroups
{
    public class GetAllItemGroupsQuery : IRequest<PaginatedList<ItemGroupDto>>
    {
        public string SearchTerm { get; set; }
        public string SortBy { get; set; }
        public bool SortDescending { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 