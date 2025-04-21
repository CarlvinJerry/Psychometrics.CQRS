using MediatR;
using System;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.UpdateItemSubGroup;

/// <summary>
/// Command to update an ItemSubGroup
/// </summary>
public class UpdateItemSubGroupCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets the ID of the ItemSubGroup to update
    /// </summary>
    public Guid ItemSubGroupID { get; set; }

    /// <summary>
    /// Gets or sets the name of the ItemSubGroup
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the ItemSubGroup
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the code of the ItemSubGroup
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ID of the parent ItemGroup
    /// </summary>
    public Guid ItemGroupID { get; set; }

    /// <summary>
    /// Gets or sets the ID of the ItemSubGroupType
    /// </summary>
    public Guid ItemSubGroupTypeID { get; set; }
} 