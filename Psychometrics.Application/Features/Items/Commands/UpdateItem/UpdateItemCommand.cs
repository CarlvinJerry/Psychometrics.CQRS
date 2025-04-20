using MediatR;
using System;

namespace Psychometrics.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public Guid ItemGroupId { get; set; }
        public Guid? ItemSubGroupId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
} 