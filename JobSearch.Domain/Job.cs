using JobSearch.Domain.Utility;

namespace JobSearch.Domain;

public class Job : BaseDomainEntity
{
    public string? CompanyName { get; set; }
    public string? VacancyName { get; set; }
    public string? Comment { get; set; }
    public string? FullUrl { get; set; }
}
