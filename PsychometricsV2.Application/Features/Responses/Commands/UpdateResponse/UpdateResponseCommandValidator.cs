using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.Responses.Commands.UpdateResponse;

public class UpdateResponseCommandValidator : AbstractValidator<UpdateResponseCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateResponseCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("ID is required");

        RuleFor(v => v.ResponseValue)
            .NotEmpty().WithMessage("Response value is required");

        RuleFor(v => v.StudentId)
            .NotEmpty().WithMessage("Student ID is required")
            .MustAsync(StudentExists).WithMessage("Student does not exist");

        RuleFor(v => v.ItemId)
            .NotEmpty().WithMessage("Item ID is required")
            .MustAsync(ItemExists).WithMessage("Item does not exist");

        RuleFor(v => v.CalendarYear)
            .NotEmpty().WithMessage("Calendar year is required")
            .GreaterThan(1900).WithMessage("Calendar year must be after 1900")
            .LessThanOrEqualTo(DateTime.UtcNow.Year).WithMessage("Calendar year cannot be in the future");

        RuleFor(v => v.TeachingPeriod)
            .NotEmpty().WithMessage("Teaching period is required")
            .InclusiveBetween(1, 4).WithMessage("Teaching period must be between 1 and 4");

        RuleFor(v => v.MscaaId)
            .MaximumLength(50).WithMessage("MSCAA ID must not exceed 50 characters");
    }

    private async Task<bool> StudentExists(int studentId, CancellationToken cancellationToken)
    {
        return await _context.Students.AnyAsync(s => s.StudentId == studentId, cancellationToken);
    }

    private async Task<bool> ItemExists(Guid itemId, CancellationToken cancellationToken)
    {
        return await _context.Items.AnyAsync(i => i.Id == itemId, cancellationToken);
    }
} 