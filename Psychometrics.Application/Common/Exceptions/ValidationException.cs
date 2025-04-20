namespace Psychometrics.Application.Common.Exceptions;

/// <summary>
/// Exception thrown when validation fails
/// </summary>
public class ValidationException : ApplicationException
{
    /// <summary>
    /// Gets the validation errors
    /// </summary>
    public IDictionary<string, string[]> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the ValidationException class
    /// </summary>
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    /// <summary>
    /// Initializes a new instance of the ValidationException class with validation errors
    /// </summary>
    /// <param name="errors">The validation errors</param>
    public ValidationException(IDictionary<string, string[]> errors)
        : this()
    {
        Errors = errors;
    }
} 