using Microsoft.EntityFrameworkCore;
using Farlo.Insight.Domain.Entities;
using MassTransit;
using System.Collections.Generic;

namespace Farlo.Insight.Infrastructure.Persistence;

public class InsightDbContext : DbContext
{
    public InsightDbContext(DbContextOptions<InsightDbContext> options) : base(options) { }

    public DbSet<Domain.Entities.Insight> Insights => Set<Domain.Entities.Insight>();
}
