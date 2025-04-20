using System;

namespace Psychometrics.Application.Features.Students.Queries.GetAllStudents
{
    /// <summary>
    /// Data transfer object for Student entities.
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the student.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the student's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the student's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the student's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the student's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the student record.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update timestamp of the student record.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
} 