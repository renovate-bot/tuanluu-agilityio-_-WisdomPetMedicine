using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain;
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

public class ManagementRepository(ManagementDbContext managementDbContext) : IManagementRepository
{
    public void Delete(Pet pet)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pet> GetAll()
    {
        throw new NotImplementedException();
    }

    public Pet? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Insert(Pet pet)
    {
        throw new NotImplementedException();
    }

    public void Update(Pet pet)
    {
        throw new NotImplementedException();
    }
}