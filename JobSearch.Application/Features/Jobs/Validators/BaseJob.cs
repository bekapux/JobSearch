namespace JobSearch.Application.Features.Jobs.Validators;

public abstract record BaseJob
{
    public string CompanyName {get;set; }
    public string VacancyName {get;set;}
    public string Comment {get;set;}
    public string FullUrl {get;set;}
    public DateTime DateCreated {get;set;}
    public bool? IsActive {get;set;}
}
