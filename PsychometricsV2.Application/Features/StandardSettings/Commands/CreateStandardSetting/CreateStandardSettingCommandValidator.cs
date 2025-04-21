using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.CreateStandardSetting;

public class CreateStandardSettingCommandValidator : AbstractValidator<CreateStandardSettingCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateStandardSettingCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Method)
            .NotEmpty().WithMessage("Method is required")
            .MaximumLength(200).WithMessage("Method must not exceed 200 characters");

        RuleFor(v => v.RecordMonth)
            .MaximumLength(50).WithMessage("RecordMonth must not exceed 50 characters");

        RuleFor(v => v.CalendarYear)
            .MaximumLength(50).WithMessage("CalendarYear must not exceed 50 characters");

        RuleFor(v => v.AcademicYear)
            .MaximumLength(50).WithMessage("AcademicYear must not exceed 50 characters");

        RuleFor(v => v.Category)
            .MaximumLength(50).WithMessage("Category must not exceed 50 characters");

        RuleFor(v => v.Type)
            .MaximumLength(50).WithMessage("Type must not exceed 50 characters");

        RuleFor(v => v.TeachingPeriod)
            .MaximumLength(50).WithMessage("TeachingPeriod must not exceed 50 characters");
    }
} 