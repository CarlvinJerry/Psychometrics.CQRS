using System;
using MediatR;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType
{
    public class CreateItemSubGroupTypeCommand : IRequest<Guid>
    {
        public required string Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
} 