using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Interfaces;
using Psychometrics.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Psychometrics.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Responses)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.StudentId);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Responses)
                .WithOne(r => r.Item)
                .HasForeignKey(r => r.ItemId);

            modelBuilder.Entity<ItemGroup>()
                .HasMany(g => g.Items)
                .WithOne(i => i.ItemGroup)
                .HasForeignKey(i => i.ItemGroupId);
        }
    }
} 