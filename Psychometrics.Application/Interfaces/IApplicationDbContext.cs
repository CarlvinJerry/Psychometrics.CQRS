using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Response> Responses { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<ItemGroup> ItemGroups { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
} 