using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Item> Items { get; }
    DbSet<ItemGroup> ItemGroups { get; }
    DbSet<ItemSubGroup> ItemSubGroups { get; }
    DbSet<ItemSubGroupType> ItemSubGroupTypes { get; }
    DbSet<ItemResponse> ItemResponses { get; }
    DbSet<Response> Responses { get; }
    DbSet<StandardSetting> StandardSettings { get; }
    DbSet<Student> Students { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
} 