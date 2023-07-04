namespace JobSearch.Application.Features.Jobs.Mapper.Dtos;

public record JobDto(
    string CompanyName,
    string VacancyName,
    string Comment,
    string FullUrl,
    DateTime DateCreated,
    bool? IsActive
) : BaseDto;