namespace TedeeRecruitmentTask.Domain.Entities.AuditEntities;

public class AuditEntity
{
    public DateTimeOffset? CreatedOn { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
}
