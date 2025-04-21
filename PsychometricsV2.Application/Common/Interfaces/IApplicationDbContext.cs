using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Item> Items { get; }
    DbSet<ItemGroup> ItemGroups { get; }
    DbSet<ItemSubGroup> ItemSubGroups { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
} 