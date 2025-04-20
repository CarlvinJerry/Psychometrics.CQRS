using System;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById
{
    public class ItemSubGroupTypeDto
    {
        public Guid ItemSubGroupTypeID { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
} 