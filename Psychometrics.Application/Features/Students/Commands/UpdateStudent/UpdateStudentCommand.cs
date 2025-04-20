using MediatR;
using System;

namespace Psychometrics.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string StudentNumber { get; set; }
    }
} 