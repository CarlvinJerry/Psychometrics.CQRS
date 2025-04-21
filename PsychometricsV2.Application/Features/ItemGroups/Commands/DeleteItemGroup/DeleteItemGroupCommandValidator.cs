using System;
using FluentValidation;

namespace PsychometricsV2.Application.Features.ItemGroups.Commands.DeleteItemGroup;

public class DeleteItemGroupCommandValidator : AbstractValidator<DeleteItemGroupCommand>
{
    public DeleteItemGroupCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Item group ID is required");
    }
} 