using System;
using System.Collections.Generic;

namespace Psychometrics.Domain.Entities
{
    public class Response
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ItemId { get; set; }
        public required string SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime ResponseTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public required Student Student { get; set; }
        public required Item Item { get; set; }
    }
} 