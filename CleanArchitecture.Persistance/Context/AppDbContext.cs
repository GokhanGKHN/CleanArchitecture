using CleanArchitecture.Domain.Apstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    override protected void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefence).Assembly);

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries<Entity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added) 
            {
                entry.Property(p => p.CreateDate).CurrentValue = DateTime.Now;
            }
            if (entry.State == EntityState.Modified) 
            {
                entry.Property(p => p.UpdateDate).CurrentValue = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
