using System;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.ItemSubGroups.Queries.GetItemSubGroupById;

public class GetItemSubGroupByIdQuery : IRequest<ItemSubGroup?>
{
    public Guid Id { get; set; }
} 