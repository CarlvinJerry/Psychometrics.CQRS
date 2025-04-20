using System;

namespace Psychometrics.Application.Features.ItemSubGroups.Queries.GetAllItemSubGroups
{
    public class ItemSubGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ItemGroupId { get; set; }
        public string ItemGroupName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 