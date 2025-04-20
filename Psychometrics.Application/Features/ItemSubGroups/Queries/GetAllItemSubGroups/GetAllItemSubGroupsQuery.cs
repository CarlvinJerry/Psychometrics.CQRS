using MediatR;
using Psychometrics.Application.Common.Models;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups
{
    public class GetAllItemSubGroupsQuery : IRequest<PaginatedList<ItemSubGroupDto>>
    {
        public string SearchTerm { get; set; }
        public string SortBy { get; set; }
        public bool SortDescending { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Guid? ItemGroupId { get; set; }
    }
} 