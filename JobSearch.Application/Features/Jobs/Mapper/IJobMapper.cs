﻿using JobSearch.Application.Features.Jobs.Commands;
using JobSearch.Application.Features.Jobs.Mapper.Dtos;

namespace JobSearch.Application.Features.Jobs.Mapper;

public interface IJobMapper
{
    JobDto Job_To_JobDto(Job job);
    Job JobAddC_To_Job(JobAddC job);
    IEnumerable<JobDto> JobList_To_JobDtoList(IEnumerable<Job> job);
    void JobUpdateC_To_Job(JobUpdateC jobUpdateC, Job job);
    PaginatedListResult<JobDto> Jobs_To_JobDto(PaginatedListResult<Job> jobs);
}
