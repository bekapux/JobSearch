namespace JobSearch.Application.Features.Jobs.Mapper;

public interface IJobMapper
{
    JobDto JobToJobDto(Job job);
    IEnumerable<JobDto> JobListToJobDtoList(IEnumerable<Job> job);
}
