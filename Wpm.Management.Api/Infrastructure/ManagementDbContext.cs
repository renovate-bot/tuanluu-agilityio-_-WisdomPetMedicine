using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infrastructure;

public class ManagementDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pet>().HasKey(p => p.Id);
        modelBuilder.Entity<Pet>().Property(p => p.BreedId)
                                .HasConversion(v => v.Value, v => BreedId.Create(v));
        modelBuilder.Entity<Pet>().OwnsOne(p => p.Weight);
    }
}

public static class ManagementDbContextExtensions
{
    public static void EnsureDbIsCreated(this IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        ManagementDbContext? dbContext = scope.ServiceProvider.GetService<ManagementDbContext>();
        dbContext.Database.EnsureCreated();
        dbContext.Database.CloseConnection();
    }
}