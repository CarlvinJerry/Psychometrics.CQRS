using System;

namespace Psychometrics.Application.Common.Exceptions
{
    /// <summary>
    /// Exception thrown when a requested entity is not found.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the NotFoundException class.
        /// </summary>
        /// <param name="name">The name of the entity.</param>
        /// <param name="key">The key that was used to search for the entity.</param>
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
} 