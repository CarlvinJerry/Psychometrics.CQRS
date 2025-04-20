using MediatR;
using System;

namespace Psychometrics.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }
} 