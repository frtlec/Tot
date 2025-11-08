using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tot.Domain.Entities.Question;
using Tot.Domain.Enums;

namespace Tot.Infrastructure.Persistence.Configurations;

public class QuestionPoolConfiguration : IEntityTypeConfiguration<QuestionPool>
{
    public void Configure(EntityTypeBuilder<QuestionPool> builder)
    {
        builder.ToTable("QuestionPools", "Question");

        builder.HasKey(q => q.Id);
        builder.Property(q => q.Question).IsRequired();

        builder.HasOne(q => q.QuestionPoolCategory)
               .WithMany()
               .HasForeignKey(q => q.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class QuestionPoolItemConfiguration : IEntityTypeConfiguration<QuestionPoolItem>
{
    public void Configure(EntityTypeBuilder<QuestionPoolItem> builder)
    {
        builder.ToTable("QuestionPoolItems", "Question");

        builder.HasKey(q => q.Id);
    }
}

public class QuestionPoolCategoryConfiguration : IEntityTypeConfiguration<QuestionPoolCategory>
{
    public void Configure(EntityTypeBuilder<QuestionPoolCategory> builder)
    {
        builder.ToTable("QuestionPoolCategories", "Question");

        builder.HasKey(q => q.Id);


    }
}