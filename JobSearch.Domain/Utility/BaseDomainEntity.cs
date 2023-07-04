namespace JobSearch.Domain.Utility;

public class BaseDomainEntity : IBaseDomainEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
}
