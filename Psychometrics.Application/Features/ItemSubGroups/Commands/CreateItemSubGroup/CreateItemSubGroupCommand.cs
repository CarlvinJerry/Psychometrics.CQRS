using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup
{
    /// <summary>
    /// Command to create a new ItemSubGroup.
    /// </summary>
    public class CreateItemSubGroupCommand : IRequest<Guid>
    {
        /// <summary>
        /// Gets or sets the name of the ItemSubGroup.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the ItemSubGroup.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the code of the ItemSubGroup.
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ItemGroup code.
        /// </summary>
        public string ItemGroupCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ItemSubGroupType code.
        /// </summary>
        public string ItemSubGroupTypeCode { get; set; } = string.Empty;
    }
} 