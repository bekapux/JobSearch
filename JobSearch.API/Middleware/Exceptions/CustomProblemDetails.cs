using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Middleware.Exceptions;

public class CustomProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
