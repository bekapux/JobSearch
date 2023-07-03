using JobSearch.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.DBConfig.Seed
{
    internal class JobsSeed : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasData(
                new Job
                {
                    Id = 1,
                    Comment = "Comment",
                    CompanyName = "Google",
                    DateCreated = DateTime.UtcNow,
                    FullUrl = "https://google.com",
                    VacancyName = "Developer",
                    IsActive = true,
                    IsDeleted = false,
                    LastModifiedDate = DateTime.UtcNow.AddDays(-20)
                });
        }
    }
}
