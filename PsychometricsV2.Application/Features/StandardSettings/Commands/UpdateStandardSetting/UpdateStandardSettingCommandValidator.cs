using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.StandardSettings.Commands.UpdateStandardSetting;

public class UpdateStandardSettingCommandValidator : AbstractValidator<UpdateStandardSettingCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStandardSettingCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(v => v.Method)
            .NotEmpty().WithMessage("Method is required")
            .MaximumLength(200).WithMessage("Method must not exceed 200 characters");

        RuleFor(v => v.RecordMonth)
            .MaximumLength(50).WithMessage("Record Month must not exceed 50 characters");

        RuleFor(v => v.CalendarYear)
            .MaximumLength(10).WithMessage("Calendar Year must not exceed 10 characters");

        RuleFor(v => v.AcademicYear)
            .MaximumLength(10).WithMessage("Academic Year must not exceed 10 characters");

        RuleFor(v => v.Category)
            .MaximumLength(100).WithMessage("Category must not exceed 100 characters");

        RuleFor(v => v.Type)
            .MaximumLength(100).WithMessage("Type must not exceed 100 characters");

        RuleFor(v => v.TeachingPeriod)
            .MaximumLength(100).WithMessage("Teaching Period must not exceed 100 characters");

        RuleFor(v => v.YearLevel)
            .InclusiveBetween(1, 12).When(v => v.YearLevel.HasValue)
            .WithMessage("Year Level must be between 1 and 12");

        RuleFor(v => v.Phase)
            .InclusiveBetween(1, 4).When(v => v.Phase.HasValue)
            .WithMessage("Phase must be between 1 and 4");

        RuleFor(v => v.PassingScore)
            .GreaterThanOrEqualTo(0).When(v => v.PassingScore.HasValue)
            .WithMessage("Passing Score must be greater than or equal to 0");

        RuleFor(v => v.EXCScore)
            .GreaterThanOrEqualTo(0).When(v => v.EXCScore.HasValue)
            .WithMessage("EXC Score must be greater than or equal to 0");

        RuleFor(v => v.MaxScoreRaw)
            .GreaterThanOrEqualTo(0).When(v => v.MaxScoreRaw.HasValue)
            .WithMessage("Max Score Raw must be greater than or equal to 0");
    }
} 