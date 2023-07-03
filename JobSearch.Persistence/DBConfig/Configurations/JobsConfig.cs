using JobSearch.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.DBConfig.Configurations;

internal class JobsConfig : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        #region Default

        builder.HasKey(x => x.Id);
        builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired();
        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();

        #endregion

        #region Config

        builder.Property(x=> x.Comment).HasMaxLength(1000).IsRequired();
        builder.Property(x=> x.VacancyName).HasMaxLength(1000).IsRequired();
        builder.Property(x=> x.CompanyName).HasMaxLength(100).IsRequired();

        #endregion

        #region Indexes

        builder.HasIndex(x=> x.CompanyName);

        #endregion
    }
}
