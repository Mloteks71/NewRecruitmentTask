using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TedeeRecruitmentTask.Domain.Entities;
using TedeeRecruitmentTask.Infrastructure.Persistance.Configurations.Abstractions;

namespace TedeeRecruitmentTask.Infrastructure.Persistance.Configurations;
internal class TripConfiguration : AuditEntityConfiguration<Trip>
{
    public override void Configure(EntityTypeBuilder<Trip> builder)
    {
        base.Configure(builder);

        builder.HasKey(b => b.Id);
        builder.OwnsOne(b => b.Name,
        t =>
        {
            t.Property(p => p.Value).HasColumnName("TimeZone").HasMaxLength(128).IsRequired();
        });
        builder.OwnsOne(b => b.Country,
        t =>
        {
            t.Property(p => p.Value).HasColumnName("Country").IsRequired();
        });
        builder.OwnsOne(b => b.Description,
        t =>
        {
            t.Property(p => p.Value).HasColumnName("Description").HasMaxLength(2000).IsRequired();
        });
        builder.OwnsOne(b => b.StartDate,
        t =>
        {
            t.Property(p => p.Value).HasColumnName("StartDate").IsRequired();
        });
        builder.OwnsOne(b => b.SeatsCount,
        t =>
        {
            t.Property(p => p.Value).HasColumnName("SeatsCount").IsRequired();
        });
        builder.HasMany(b => b.RegisteredEmails)
            .WithOne(b => b.Trip)
            .HasForeignKey(b => b.TripId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
