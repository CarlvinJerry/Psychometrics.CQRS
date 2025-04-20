using System;
using MediatR;

namespace Psychometrics.Application.Features.Responses.Commands.CreateResponse
{
    public class CreateResponseCommand : IRequest<Guid>
    {
        public Guid StudentId { get; set; }
        public Guid ItemId { get; set; }
        public required string SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime ResponseTime { get; set; }
    }
} 