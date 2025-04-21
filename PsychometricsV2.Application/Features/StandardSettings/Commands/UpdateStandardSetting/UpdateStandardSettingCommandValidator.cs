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

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(v => v.Code)
            .NotEmpty().WithMessage("Code is required")
            .MaximumLength(50).WithMessage("Code must not exceed 50 characters")
            .MustAsync(BeUniqueCode).WithMessage("The specified code already exists");

        RuleFor(v => v.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");
    }

    private async Task<bool> BeUniqueCode(UpdateStandardSettingCommand command, string code, CancellationToken cancellationToken)
    {
        return !await _context.StandardSettings
            .AnyAsync(s => s.Code == code && s.Id != command.Id, cancellationToken);
    }
} 