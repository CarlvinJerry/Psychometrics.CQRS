using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.DeleteItemSubGroup;

/// <summary>
/// Command to delete an ItemSubGroup
/// </summary>
public class DeleteItemSubGroupCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets the ID of the ItemSubGroup to delete
    /// </summary>
    public Guid ItemSubGroupID { get; set; }
} 