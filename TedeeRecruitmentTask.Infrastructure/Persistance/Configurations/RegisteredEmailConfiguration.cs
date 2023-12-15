using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TedeeRecruitmentTask.Domain.Entities;
using TedeeRecruitmentTask.Infrastructure.Persistance.Configurations.Abstractions;

namespace TedeeRecruitmentTask.Infrastructure.Persistance.Configurations;
internal class RegisteredEmailConfiguration : AuditEntityConfiguration<RegisteredEmail>
{
    public override void Configure(EntityTypeBuilder<RegisteredEmail> builder)
    {
        base.Configure(builder);

        builder.HasKey(b => b.Id);
        builder.OwnsOne(b => b.Email,
        t =>
        {
            t.Property(p => p.Value).HasColumnName("Email").HasMaxLength(128).IsRequired();
        });
    }
}
