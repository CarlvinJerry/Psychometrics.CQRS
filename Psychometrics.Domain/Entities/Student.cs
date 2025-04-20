using System;
using System.Collections.Generic;

namespace Psychometrics.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string StudentNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation properties
        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }
} 