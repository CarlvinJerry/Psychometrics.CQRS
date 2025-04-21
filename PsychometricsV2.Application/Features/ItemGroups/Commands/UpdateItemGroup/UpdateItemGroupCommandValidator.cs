using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.UpdateItemGroup;

public class UpdateItemGroupCommandValidator : AbstractValidator<UpdateItemGroupCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateItemGroupCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .NotEmpty();

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

    private async Task<bool> BeUniqueCode(UpdateItemGroupCommand command, string code, CancellationToken cancellationToken)
    {
        return !await _context.ItemGroups
            .AnyAsync(ig => ig.Code == code && ig.Id != command.Id, cancellationToken);
    }
} 