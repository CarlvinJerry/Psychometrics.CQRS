using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<ItemGroup> ItemGroups { get; set; } = null!;
    public DbSet<ItemSubGroup> ItemSubGroups { get; set; } = null!;
    public DbSet<ItemSubGroupType> ItemSubGroupTypes { get; set; } = null!;
    public DbSet<ItemResponse> ItemResponses { get; set; } = null!;
    public DbSet<Response> Responses { get; set; } = null!;
    public DbSet<StandardSetting> StandardSettings { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure unique codes
        modelBuilder.Entity<Item>()
            .HasIndex(i => i.Code)
            .IsUnique();

        modelBuilder.Entity<ItemGroup>()
            .HasIndex(ig => ig.Code)
            .IsUnique();

        modelBuilder.Entity<ItemSubGroup>()
            .HasIndex(isg => isg.Code)
            .IsUnique();

        modelBuilder.Entity<ItemSubGroupType>()
            .HasIndex(isgt => isgt.Code)
            .IsUnique();

        // Configure relationships and constraints
        modelBuilder.Entity<Item>()
            .HasOne(i => i.ItemSubGroup)
            .WithMany(isg => isg.Items)
            .HasForeignKey(i => i.ItemSubGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemSubGroup>()
            .HasOne(isg => isg.ItemGroup)
            .WithMany(ig => ig.ItemSubGroups)
            .HasForeignKey(isg => isg.ItemGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemSubGroup>()
            .HasOne(isg => isg.ItemSubGroupType)
            .WithMany(isgt => isgt.ItemSubGroups)
            .HasForeignKey(isg => isg.ItemSubGroupTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Response>()
            .HasOne(r => r.Student)
            .WithMany(s => s.Responses)
            .HasForeignKey(r => r.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Response>()
            .HasOne(r => r.Item)
            .WithMany()
            .HasForeignKey(r => r.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemResponse>()
            .HasOne(ir => ir.Item)
            .WithMany(i => i.ItemResponses)
            .HasForeignKey(ir => ir.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemResponse>()
            .HasOne(ir => ir.Response)
            .WithMany(r => r.ItemResponses)
            .HasForeignKey(ir => ir.ResponseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure decimal precision
        modelBuilder.Entity<Response>()
            .Property(r => r.ResponseValue)
            .HasPrecision(18, 4);
    }
} 