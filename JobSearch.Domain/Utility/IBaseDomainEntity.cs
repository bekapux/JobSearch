namespace JobSearch.Domain.Utility;

public interface IBaseDomainEntity
{
    DateTime DateCreated { get; set; }
    int Id { get; set; }
    bool? IsActive { get; set; }
    bool? IsDeleted { get; set; }
    DateTime? LastModifiedDate { get; set; }
}