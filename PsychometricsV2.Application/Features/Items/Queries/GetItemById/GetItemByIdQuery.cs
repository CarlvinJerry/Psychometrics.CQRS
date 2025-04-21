using System;
using MediatR;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Items.Queries.GetItemById;

public class GetItemByIdQuery : IRequest<Item?>
{
    public Guid Id { get; set; }
} 