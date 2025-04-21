using System;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroupTypes.Queries.GetItemSubGroupTypeById;

public class GetItemSubGroupTypeByIdQuery : IRequest<ItemSubGroupType?>
{
    public Guid Id { get; set; }
} 