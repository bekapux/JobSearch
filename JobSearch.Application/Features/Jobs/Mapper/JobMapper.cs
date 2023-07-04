using Riok.Mapperly.Abstractions;

namespace JobSearch.Application.Features.Jobs.Mapper;

[Mapper]
public partial class JobMapper : IJobMapper
{
    public partial JobDto JobToJobDto(Job job);
    public partial IEnumerable<JobDto> JobListToJobDtoList(IEnumerable<Job> job);
}
