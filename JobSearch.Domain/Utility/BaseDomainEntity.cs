global using JobSearch.Domain.Utility;

namespace JobSearch.Domain.Utility;

public class BaseDomainEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
}
