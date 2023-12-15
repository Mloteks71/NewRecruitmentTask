using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TedeeRecruitmentTask.Domain.Entities.AuditEntities;

namespace TedeeRecruitmentTask.Infrastructure.Persistance.Configurations.Abstractions;
internal abstract class AuditEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}