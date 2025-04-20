using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.DeleteItemSubGroupType
{
    public class DeleteItemSubGroupTypeCommand : IRequest<bool>
    {
        public Guid ItemSubGroupTypeID { get; set; }
    }
} 