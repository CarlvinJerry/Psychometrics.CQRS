using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.UpdateItemSubGroupType
{
    public class UpdateItemSubGroupTypeCommand : IRequest<bool>
    {
        public Guid ItemSubGroupTypeID { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
} 