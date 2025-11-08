using Microsoft.EntityFrameworkCore;
using Tot.Domain.Entities.Question;

namespace Tot.Infrastructure.Persistence;

public class TotPostgreSqlDbContext:DbContext
{
    public TotPostgreSqlDbContext(DbContextOptions<TotPostgreSqlDbContext> options)
     : base(options)
    {
    }

    // --- DbSet'ler ---
    public DbSet<QuestionPool> QuestionPools => Set<QuestionPool>();
    public DbSet<QuestionPoolItem> QuestionPoolItems => Set<QuestionPoolItem>();
    public DbSet<QuestionPoolCategory> QuestionPoolCategories => Set<QuestionPoolCategory>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Bütün enum property'leri string olarak kaydet
        configurationBuilder
            .Properties<Enum>()
            .HaveConversion<string>();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TotPostgreSqlDbContext).Assembly);
    }
}
