using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for the application database context.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Gets or sets the Students DbSet.
        /// </summary>
        DbSet<Student> Students { get; set; }

        /// <summary>
        /// Gets or sets the ItemResponses DbSet.
        /// </summary>
        DbSet<ItemResponse> ItemResponses { get; set; }

        /// <summary>
        /// Gets or sets the Items DbSet.
        /// </summary>
        DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets the ItemGroups DbSet.
        /// </summary>
        DbSet<ItemGroup> ItemGroups { get; set; }

        /// <summary>
        /// Gets or sets the ItemSubGroups DbSet.
        /// </summary>
        DbSet<ItemSubGroup> ItemSubGroups { get; set; }

        /// <summary>
        /// Gets or sets the ItemSubGroupTypes DbSet.
        /// </summary>
        DbSet<ItemSubGroupType> ItemSubGroupTypes { get; set; }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
} 