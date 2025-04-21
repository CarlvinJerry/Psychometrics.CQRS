using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.CreateItemGroup;

public class CreateItemGroupCommandValidator : AbstractValidator<CreateItemGroupCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateItemGroupCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(v => v.Code)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(BeUniqueCode).WithMessage("The specified code already exists.");

        RuleFor(v => v.Description)
            .MaximumLength(500);
    }

    private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
    {
        return !await _context.ItemGroups
            .AnyAsync(ig => ig.Code == code, cancellationToken);
    }
} 