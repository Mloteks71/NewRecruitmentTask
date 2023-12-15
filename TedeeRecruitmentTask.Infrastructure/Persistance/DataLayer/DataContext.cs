using Microsoft.EntityFrameworkCore;
using TedeeRecruitmentTask.Domain.Entities;
using TedeeRecruitmentTask.Domain.Entities.AuditEntities;
using TedeeRecruitmentTask.Infrastructure.Persistance.Configurations;

namespace TedeeRecruitmentTask.Infrastructure.Persistance.DataLayer;
public class DataContext : DbContext
{
    #region ctors
    internal DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    #endregion
    #region DbSets
    public virtual DbSet<Trip> Trips => Set<Trip>();
    public virtual DbSet<RegisteredEmail> RegisteredEmails => Set<RegisteredEmail>();
    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder == null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TripConfiguration());
        modelBuilder.ApplyConfiguration(new RegisteredEmailConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<AuditEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = now;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedOn = now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}
