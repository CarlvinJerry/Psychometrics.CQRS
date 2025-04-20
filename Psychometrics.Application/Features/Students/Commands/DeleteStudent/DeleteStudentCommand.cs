using MediatR;
using System;

namespace Psychometrics.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
} 