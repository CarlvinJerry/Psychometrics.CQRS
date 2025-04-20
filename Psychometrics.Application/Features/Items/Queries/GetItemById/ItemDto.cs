using System;

namespace Psychometrics.Application.Features.Items.Queries.GetItemById
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public Guid ItemGroupId { get; set; }
        public Guid? ItemSubGroupId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 