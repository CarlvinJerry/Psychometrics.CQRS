using MediatR;
using System;

namespace Psychometrics.Application.Features.Students.Commands.DeleteStudent
{
    /// <summary>
    /// Command to delete a Student
    /// </summary>
    public class DeleteStudentCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the ID of the Student to delete
        /// </summary>
        public Guid StudentID { get; set; }
    }
} 