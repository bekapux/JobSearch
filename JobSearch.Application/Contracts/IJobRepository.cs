namespace JobSearch.Application.Contracts;

public interface IJobRepository : IGenericRepository<Job>
{
    Task<List<Job>> GetJobsByCompanyName(string companyNameFragment);
}
