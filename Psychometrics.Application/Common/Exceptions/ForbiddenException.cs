namespace Psychometrics.Application.Common.Exceptions;

/// <summary>
/// Exception thrown when access is forbidden
/// </summary>
public class ForbiddenException : ApplicationException
{
    /// <summary>
    /// Initializes a new instance of the ForbiddenException class
    /// </summary>
    public ForbiddenException()
        : base("Access to the requested resource is forbidden.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the ForbiddenException class with a specified error message
    /// </summary>
    /// <param name="message">The message that describes the error</param>
    public ForbiddenException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the ForbiddenException class with a specified error message and a reference to the inner exception
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception</param>
    /// <param name="innerException">The exception that is the cause of the current exception</param>
    public ForbiddenException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
} 