using Farlo.Insight.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farlo.Insight.Infrastructure.Persistence;

public class InsightDbContext : DbContext
{
    public InsightDbContext(DbContextOptions<InsightDbContext> options) : base(options) { }

    public DbSet<Domain.Entities.Insight> AIInsights => Set<Domain.Entities.Insight>();
    public DbSet<CultureInsight> CultureInsights => Set<CultureInsight>();
}
