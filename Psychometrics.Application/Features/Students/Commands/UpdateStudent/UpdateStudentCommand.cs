using MediatR;
using System;

namespace Psychometrics.Application.Features.Students.Commands.UpdateStudent
{
    /// <summary>
    /// Command to update a Student
    /// </summary>
    public class UpdateStudentCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the ID of the Student to update
        /// </summary>
        public Guid StudentID { get; set; }

        /// <summary>
        /// Gets or sets the first name of the Student
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the Student
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the Student
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the Student
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the Student
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the gender of the Student
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the student number of the Student
        /// </summary>
        public string StudentNumber { get; set; }
    }
} 