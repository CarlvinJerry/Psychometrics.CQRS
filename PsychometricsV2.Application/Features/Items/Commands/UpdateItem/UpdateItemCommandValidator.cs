using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Common.Interfaces;

namespace PsychometricsV2.Application.Features.Items.Commands.UpdateItem;

public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateItemCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .NotEmpty();

        RuleFor(v => v.Code)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(BeUniqueCode)
                .WithMessage("The specified code already exists.");

        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(v => v.Description)
            .MaximumLength(500);

        RuleFor(v => v.ItemSubGroupId)
            .NotEmpty()
            .MustAsync(ItemSubGroupExists)
                .WithMessage("The specified Item Sub Group doesn't exist.");
    }

    private async Task<bool> BeUniqueCode(UpdateItemCommand command, string code, CancellationToken cancellationToken)
    {
        return await _context.Items
            .Where(i => i.Id != command.Id)
            .AllAsync(i => i.Code != code, cancellationToken);
    }

    private async Task<bool> ItemSubGroupExists(Guid id, CancellationToken cancellationToken)
    {
        return await _context.ItemSubGroups.AnyAsync(isg => isg.Id == id, cancellationToken);
    }
} 