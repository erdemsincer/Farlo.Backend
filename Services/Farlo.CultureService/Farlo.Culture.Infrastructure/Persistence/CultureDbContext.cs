using Farlo.Culture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farlo.Culture.Infrastructure.Persistence;

public class CultureDbContext : DbContext
{
    public CultureDbContext(DbContextOptions<CultureDbContext> options) : base(options) { }

    public DbSet<CultureInsight> CultureInsights => Set<CultureInsight>();
}
