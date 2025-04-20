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
        public NotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotFoundException class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotFoundException class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

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