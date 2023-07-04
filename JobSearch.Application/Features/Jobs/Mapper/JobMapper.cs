using JobSearch.Application.Features.Jobs.Commands;
using Riok.Mapperly.Abstractions;

namespace JobSearch.Application.Features.Jobs.Mapper;

[Mapper]
public partial class JobMapper : IJobMapper
{
    public partial JobDto Job_To_JobDto(Job job);
    public partial IEnumerable<JobDto> JobList_To_JobDtoList(IEnumerable<Job> job);
    public partial Job JobAddC_To_Job(JobAddC job);
    public partial void JobUpdateC_To_Job(JobUpdateC jobUpdateC, Job job);
}
