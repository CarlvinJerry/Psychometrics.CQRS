using FluentValidation;

namespace PsychometricsV2.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(v => v.CandidateNumber)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(v => v.EmailAddress)
            .NotEmpty()
            .EmailAddress();

        RuleFor(v => v.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(v => v.Surname)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(v => v.Year)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(v => v.YearOfEntry)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(v => v.AcademicYear)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(v => v.Block)
            .GreaterThan(0);

        RuleFor(v => v.AgeOnEntry)
            .GreaterThan(0)
            .LessThan(150);

        RuleFor(v => v.HomeAddress)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(v => v.LocalNonLocalWP)
            .NotEmpty()
            .MaximumLength(50);
    }
} 